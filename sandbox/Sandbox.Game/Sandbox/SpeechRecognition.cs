using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Speech.Recognition;

namespace Sandbox
{
	// Token: 0x020000B4 RID: 180
	public static class SpeechRecognition
	{
		/// <summary>
		/// Whether or not we are currently listening for speech.
		/// </summary>
		// Token: 0x1700023F RID: 575
		// (get) Token: 0x0600117C RID: 4476 RVA: 0x0004A8EA File Offset: 0x00048AEA
		// (set) Token: 0x0600117D RID: 4477 RVA: 0x0004A8F1 File Offset: 0x00048AF1
		public static bool IsListening { get; private set; }

		/// <summary>
		/// Whether or not speech recognition is supported and a language is available.
		/// </summary>
		// Token: 0x17000240 RID: 576
		// (get) Token: 0x0600117E RID: 4478 RVA: 0x0004A8F9 File Offset: 0x00048AF9
		public static bool IsSupported
		{
			get
			{
				return SpeechRecognition.GetRecognizerInfo() != null;
			}
		}

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x0600117F RID: 4479 RVA: 0x0004A903 File Offset: 0x00048B03
		// (set) Token: 0x06001180 RID: 4480 RVA: 0x0004A90A File Offset: 0x00048B0A
		private static SpeechRecognitionEngine Engine { get; set; }

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x06001181 RID: 4481 RVA: 0x0004A912 File Offset: 0x00048B12
		// (set) Token: 0x06001182 RID: 4482 RVA: 0x0004A919 File Offset: 0x00048B19
		private static RecognizerInfo RecognizerInfo { get; set; }

		/// <summary>
		/// Start listening for speech to recognize as text. When speech has been recognized the callback
		/// will be invoked, the callback will also be invoked with an empty string if recognition fails.
		/// </summary>
		/// <param name="callback">
		/// A callback that will be invokved when recognition has finished.
		/// </param>
		/// <param name="choices">
		/// An array of possible choices. The closest match will be chosen and passed to
		/// the callback.
		/// </param>
		// Token: 0x06001183 RID: 4483 RVA: 0x0004A924 File Offset: 0x00048B24
		public static bool Listen(SpeechRecognition.OnSpeechRecognized callback, string[] choices = null)
		{
			Host.AssertClient("Listen");
			SpeechRecognition.Stop();
			RecognizerInfo ri = SpeechRecognition.GetRecognizerInfo();
			if (ri == null)
			{
				throw new Exception("Unable to find any installed languages");
			}
			Grammar grammar;
			if (choices != null && choices.Length != 0)
			{
				grammar = new Grammar(new GrammarBuilder(new Choices(choices))
				{
					Culture = ri.Culture
				});
			}
			else
			{
				grammar = new DictationGrammar();
			}
			SpeechRecognition.Engine = new SpeechRecognitionEngine(ri);
			SpeechRecognition.Engine.LoadGrammarAsync(grammar);
			SpeechRecognition.Engine.EndSilenceTimeout = TimeSpan.FromSeconds(1.0);
			SpeechRecognition.Engine.InitialSilenceTimeout = TimeSpan.FromSeconds(3.0);
			SpeechRecognition.Engine.SetInputToDefaultAudioDevice();
			SpeechRecognition.Engine.LoadGrammarCompleted += delegate([Nullable(2)] object sender, LoadGrammarCompletedEventArgs e)
			{
				SpeechRecognition.Engine.RecognizeAsync(RecognizeMode.Multiple);
			};
			SpeechRecognition.Engine.RecognizeCompleted += delegate([Nullable(2)] object sender, RecognizeCompletedEventArgs e)
			{
				SpeechRecognition.Stop();
				throw e.Error;
			};
			SpeechRecognition.Engine.SpeechRecognized += delegate([Nullable(2)] object sender, SpeechRecognizedEventArgs e)
			{
				SpeechRecognition.Stop();
				SpeechRecognition.OnSpeechRecognized callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2(e.Result.Text);
			};
			SpeechRecognition.Engine.SpeechRecognitionRejected += delegate([Nullable(2)] object sender, SpeechRecognitionRejectedEventArgs e)
			{
				SpeechRecognition.Stop();
				SpeechRecognition.OnSpeechRecognized callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2(e.Result.Text);
			};
			SpeechRecognition.IsListening = true;
			return true;
		}

		/// <summary>
		/// Stop any active listening for speech.
		/// </summary>
		// Token: 0x06001184 RID: 4484 RVA: 0x0004AA62 File Offset: 0x00048C62
		public static void Stop()
		{
			if (SpeechRecognition.Engine == null)
			{
				return;
			}
			SpeechRecognition.IsListening = false;
			SpeechRecognition.Engine.RecognizeAsyncCancel();
			SpeechRecognition.Engine.Dispose();
			SpeechRecognition.Engine = null;
		}

		// Token: 0x06001185 RID: 4485 RVA: 0x0004AA8C File Offset: 0x00048C8C
		private static RecognizerInfo GetRecognizerInfo()
		{
			if (SpeechRecognition.RecognizerInfo != null)
			{
				return SpeechRecognition.RecognizerInfo;
			}
			ReadOnlyCollection<RecognizerInfo> recognizerList = SpeechRecognitionEngine.InstalledRecognizers();
			foreach (RecognizerInfo ri in recognizerList)
			{
				if (ri.Culture.TwoLetterISOLanguageName.Equals("en"))
				{
					SpeechRecognition.RecognizerInfo = ri;
					break;
				}
			}
			if (SpeechRecognition.RecognizerInfo == null)
			{
				SpeechRecognition.RecognizerInfo = recognizerList.FirstOrDefault<RecognizerInfo>();
			}
			return SpeechRecognition.RecognizerInfo;
		}

		// Token: 0x06001186 RID: 4486 RVA: 0x0004AB18 File Offset: 0x00048D18
		internal static void Reset()
		{
			SpeechRecognition.RecognizerInfo = null;
			SpeechRecognition.IsListening = false;
		}

		// Token: 0x02000237 RID: 567
		// (Invoke) Token: 0x06001DD6 RID: 7638
		public delegate void OnSpeechRecognized(string text);
	}
}
