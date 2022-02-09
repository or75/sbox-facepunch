using System;

namespace Steamworks
{
	// Token: 0x02000076 RID: 118
	internal enum HTTPStatusCode
	{
		// Token: 0x04000429 RID: 1065
		Invalid,
		// Token: 0x0400042A RID: 1066
		Code100Continue = 100,
		// Token: 0x0400042B RID: 1067
		Code101SwitchingProtocols,
		// Token: 0x0400042C RID: 1068
		Code200OK = 200,
		// Token: 0x0400042D RID: 1069
		Code201Created,
		// Token: 0x0400042E RID: 1070
		Code202Accepted,
		// Token: 0x0400042F RID: 1071
		Code203NonAuthoritative,
		// Token: 0x04000430 RID: 1072
		Code204NoContent,
		// Token: 0x04000431 RID: 1073
		Code205ResetContent,
		// Token: 0x04000432 RID: 1074
		Code206PartialContent,
		// Token: 0x04000433 RID: 1075
		Code300MultipleChoices = 300,
		// Token: 0x04000434 RID: 1076
		Code301MovedPermanently,
		// Token: 0x04000435 RID: 1077
		Code302Found,
		// Token: 0x04000436 RID: 1078
		Code303SeeOther,
		// Token: 0x04000437 RID: 1079
		Code304NotModified,
		// Token: 0x04000438 RID: 1080
		Code305UseProxy,
		// Token: 0x04000439 RID: 1081
		Code307TemporaryRedirect = 307,
		// Token: 0x0400043A RID: 1082
		Code400BadRequest = 400,
		// Token: 0x0400043B RID: 1083
		Code401Unauthorized,
		// Token: 0x0400043C RID: 1084
		Code402PaymentRequired,
		// Token: 0x0400043D RID: 1085
		Code403Forbidden,
		// Token: 0x0400043E RID: 1086
		Code404NotFound,
		// Token: 0x0400043F RID: 1087
		Code405MethodNotAllowed,
		// Token: 0x04000440 RID: 1088
		Code406NotAcceptable,
		// Token: 0x04000441 RID: 1089
		Code407ProxyAuthRequired,
		// Token: 0x04000442 RID: 1090
		Code408RequestTimeout,
		// Token: 0x04000443 RID: 1091
		Code409Conflict,
		// Token: 0x04000444 RID: 1092
		Code410Gone,
		// Token: 0x04000445 RID: 1093
		Code411LengthRequired,
		// Token: 0x04000446 RID: 1094
		Code412PreconditionFailed,
		// Token: 0x04000447 RID: 1095
		Code413RequestEntityTooLarge,
		// Token: 0x04000448 RID: 1096
		Code414RequestURITooLong,
		// Token: 0x04000449 RID: 1097
		Code415UnsupportedMediaType,
		// Token: 0x0400044A RID: 1098
		Code416RequestedRangeNotSatisfiable,
		// Token: 0x0400044B RID: 1099
		Code417ExpectationFailed,
		// Token: 0x0400044C RID: 1100
		Code4xxUnknown,
		// Token: 0x0400044D RID: 1101
		Code429TooManyRequests = 429,
		// Token: 0x0400044E RID: 1102
		Code444ConnectionClosed = 444,
		// Token: 0x0400044F RID: 1103
		Code500InternalServerError = 500,
		// Token: 0x04000450 RID: 1104
		Code501NotImplemented,
		// Token: 0x04000451 RID: 1105
		Code502BadGateway,
		// Token: 0x04000452 RID: 1106
		Code503ServiceUnavailable,
		// Token: 0x04000453 RID: 1107
		Code504GatewayTimeout,
		// Token: 0x04000454 RID: 1108
		Code505HTTPVersionNotSupported,
		// Token: 0x04000455 RID: 1109
		Code5xxUnknown = 599
	}
}
