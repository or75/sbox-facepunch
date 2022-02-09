using System;

namespace Steamworks
{
	// Token: 0x02000078 RID: 120
	internal enum InputActionOrigin
	{
		// Token: 0x04000469 RID: 1129
		None,
		// Token: 0x0400046A RID: 1130
		SteamController_A,
		// Token: 0x0400046B RID: 1131
		SteamController_B,
		// Token: 0x0400046C RID: 1132
		SteamController_X,
		// Token: 0x0400046D RID: 1133
		SteamController_Y,
		// Token: 0x0400046E RID: 1134
		SteamController_LeftBumper,
		// Token: 0x0400046F RID: 1135
		SteamController_RightBumper,
		// Token: 0x04000470 RID: 1136
		SteamController_LeftGrip,
		// Token: 0x04000471 RID: 1137
		SteamController_RightGrip,
		// Token: 0x04000472 RID: 1138
		SteamController_Start,
		// Token: 0x04000473 RID: 1139
		SteamController_Back,
		// Token: 0x04000474 RID: 1140
		SteamController_LeftPad_Touch,
		// Token: 0x04000475 RID: 1141
		SteamController_LeftPad_Swipe,
		// Token: 0x04000476 RID: 1142
		SteamController_LeftPad_Click,
		// Token: 0x04000477 RID: 1143
		SteamController_LeftPad_DPadNorth,
		// Token: 0x04000478 RID: 1144
		SteamController_LeftPad_DPadSouth,
		// Token: 0x04000479 RID: 1145
		SteamController_LeftPad_DPadWest,
		// Token: 0x0400047A RID: 1146
		SteamController_LeftPad_DPadEast,
		// Token: 0x0400047B RID: 1147
		SteamController_RightPad_Touch,
		// Token: 0x0400047C RID: 1148
		SteamController_RightPad_Swipe,
		// Token: 0x0400047D RID: 1149
		SteamController_RightPad_Click,
		// Token: 0x0400047E RID: 1150
		SteamController_RightPad_DPadNorth,
		// Token: 0x0400047F RID: 1151
		SteamController_RightPad_DPadSouth,
		// Token: 0x04000480 RID: 1152
		SteamController_RightPad_DPadWest,
		// Token: 0x04000481 RID: 1153
		SteamController_RightPad_DPadEast,
		// Token: 0x04000482 RID: 1154
		SteamController_LeftTrigger_Pull,
		// Token: 0x04000483 RID: 1155
		SteamController_LeftTrigger_Click,
		// Token: 0x04000484 RID: 1156
		SteamController_RightTrigger_Pull,
		// Token: 0x04000485 RID: 1157
		SteamController_RightTrigger_Click,
		// Token: 0x04000486 RID: 1158
		SteamController_LeftStick_Move,
		// Token: 0x04000487 RID: 1159
		SteamController_LeftStick_Click,
		// Token: 0x04000488 RID: 1160
		SteamController_LeftStick_DPadNorth,
		// Token: 0x04000489 RID: 1161
		SteamController_LeftStick_DPadSouth,
		// Token: 0x0400048A RID: 1162
		SteamController_LeftStick_DPadWest,
		// Token: 0x0400048B RID: 1163
		SteamController_LeftStick_DPadEast,
		// Token: 0x0400048C RID: 1164
		SteamController_Gyro_Move,
		// Token: 0x0400048D RID: 1165
		SteamController_Gyro_Pitch,
		// Token: 0x0400048E RID: 1166
		SteamController_Gyro_Yaw,
		// Token: 0x0400048F RID: 1167
		SteamController_Gyro_Roll,
		// Token: 0x04000490 RID: 1168
		SteamController_Reserved0,
		// Token: 0x04000491 RID: 1169
		SteamController_Reserved1,
		// Token: 0x04000492 RID: 1170
		SteamController_Reserved2,
		// Token: 0x04000493 RID: 1171
		SteamController_Reserved3,
		// Token: 0x04000494 RID: 1172
		SteamController_Reserved4,
		// Token: 0x04000495 RID: 1173
		SteamController_Reserved5,
		// Token: 0x04000496 RID: 1174
		SteamController_Reserved6,
		// Token: 0x04000497 RID: 1175
		SteamController_Reserved7,
		// Token: 0x04000498 RID: 1176
		SteamController_Reserved8,
		// Token: 0x04000499 RID: 1177
		SteamController_Reserved9,
		// Token: 0x0400049A RID: 1178
		SteamController_Reserved10,
		// Token: 0x0400049B RID: 1179
		PS4_X,
		// Token: 0x0400049C RID: 1180
		PS4_Circle,
		// Token: 0x0400049D RID: 1181
		PS4_Triangle,
		// Token: 0x0400049E RID: 1182
		PS4_Square,
		// Token: 0x0400049F RID: 1183
		PS4_LeftBumper,
		// Token: 0x040004A0 RID: 1184
		PS4_RightBumper,
		// Token: 0x040004A1 RID: 1185
		PS4_Options,
		// Token: 0x040004A2 RID: 1186
		PS4_Share,
		// Token: 0x040004A3 RID: 1187
		PS4_LeftPad_Touch,
		// Token: 0x040004A4 RID: 1188
		PS4_LeftPad_Swipe,
		// Token: 0x040004A5 RID: 1189
		PS4_LeftPad_Click,
		// Token: 0x040004A6 RID: 1190
		PS4_LeftPad_DPadNorth,
		// Token: 0x040004A7 RID: 1191
		PS4_LeftPad_DPadSouth,
		// Token: 0x040004A8 RID: 1192
		PS4_LeftPad_DPadWest,
		// Token: 0x040004A9 RID: 1193
		PS4_LeftPad_DPadEast,
		// Token: 0x040004AA RID: 1194
		PS4_RightPad_Touch,
		// Token: 0x040004AB RID: 1195
		PS4_RightPad_Swipe,
		// Token: 0x040004AC RID: 1196
		PS4_RightPad_Click,
		// Token: 0x040004AD RID: 1197
		PS4_RightPad_DPadNorth,
		// Token: 0x040004AE RID: 1198
		PS4_RightPad_DPadSouth,
		// Token: 0x040004AF RID: 1199
		PS4_RightPad_DPadWest,
		// Token: 0x040004B0 RID: 1200
		PS4_RightPad_DPadEast,
		// Token: 0x040004B1 RID: 1201
		PS4_CenterPad_Touch,
		// Token: 0x040004B2 RID: 1202
		PS4_CenterPad_Swipe,
		// Token: 0x040004B3 RID: 1203
		PS4_CenterPad_Click,
		// Token: 0x040004B4 RID: 1204
		PS4_CenterPad_DPadNorth,
		// Token: 0x040004B5 RID: 1205
		PS4_CenterPad_DPadSouth,
		// Token: 0x040004B6 RID: 1206
		PS4_CenterPad_DPadWest,
		// Token: 0x040004B7 RID: 1207
		PS4_CenterPad_DPadEast,
		// Token: 0x040004B8 RID: 1208
		PS4_LeftTrigger_Pull,
		// Token: 0x040004B9 RID: 1209
		PS4_LeftTrigger_Click,
		// Token: 0x040004BA RID: 1210
		PS4_RightTrigger_Pull,
		// Token: 0x040004BB RID: 1211
		PS4_RightTrigger_Click,
		// Token: 0x040004BC RID: 1212
		PS4_LeftStick_Move,
		// Token: 0x040004BD RID: 1213
		PS4_LeftStick_Click,
		// Token: 0x040004BE RID: 1214
		PS4_LeftStick_DPadNorth,
		// Token: 0x040004BF RID: 1215
		PS4_LeftStick_DPadSouth,
		// Token: 0x040004C0 RID: 1216
		PS4_LeftStick_DPadWest,
		// Token: 0x040004C1 RID: 1217
		PS4_LeftStick_DPadEast,
		// Token: 0x040004C2 RID: 1218
		PS4_RightStick_Move,
		// Token: 0x040004C3 RID: 1219
		PS4_RightStick_Click,
		// Token: 0x040004C4 RID: 1220
		PS4_RightStick_DPadNorth,
		// Token: 0x040004C5 RID: 1221
		PS4_RightStick_DPadSouth,
		// Token: 0x040004C6 RID: 1222
		PS4_RightStick_DPadWest,
		// Token: 0x040004C7 RID: 1223
		PS4_RightStick_DPadEast,
		// Token: 0x040004C8 RID: 1224
		PS4_DPad_North,
		// Token: 0x040004C9 RID: 1225
		PS4_DPad_South,
		// Token: 0x040004CA RID: 1226
		PS4_DPad_West,
		// Token: 0x040004CB RID: 1227
		PS4_DPad_East,
		// Token: 0x040004CC RID: 1228
		PS4_Gyro_Move,
		// Token: 0x040004CD RID: 1229
		PS4_Gyro_Pitch,
		// Token: 0x040004CE RID: 1230
		PS4_Gyro_Yaw,
		// Token: 0x040004CF RID: 1231
		PS4_Gyro_Roll,
		// Token: 0x040004D0 RID: 1232
		PS4_DPad_Move,
		// Token: 0x040004D1 RID: 1233
		PS4_Reserved1,
		// Token: 0x040004D2 RID: 1234
		PS4_Reserved2,
		// Token: 0x040004D3 RID: 1235
		PS4_Reserved3,
		// Token: 0x040004D4 RID: 1236
		PS4_Reserved4,
		// Token: 0x040004D5 RID: 1237
		PS4_Reserved5,
		// Token: 0x040004D6 RID: 1238
		PS4_Reserved6,
		// Token: 0x040004D7 RID: 1239
		PS4_Reserved7,
		// Token: 0x040004D8 RID: 1240
		PS4_Reserved8,
		// Token: 0x040004D9 RID: 1241
		PS4_Reserved9,
		// Token: 0x040004DA RID: 1242
		PS4_Reserved10,
		// Token: 0x040004DB RID: 1243
		XBoxOne_A,
		// Token: 0x040004DC RID: 1244
		XBoxOne_B,
		// Token: 0x040004DD RID: 1245
		XBoxOne_X,
		// Token: 0x040004DE RID: 1246
		XBoxOne_Y,
		// Token: 0x040004DF RID: 1247
		XBoxOne_LeftBumper,
		// Token: 0x040004E0 RID: 1248
		XBoxOne_RightBumper,
		// Token: 0x040004E1 RID: 1249
		XBoxOne_Menu,
		// Token: 0x040004E2 RID: 1250
		XBoxOne_View,
		// Token: 0x040004E3 RID: 1251
		XBoxOne_LeftTrigger_Pull,
		// Token: 0x040004E4 RID: 1252
		XBoxOne_LeftTrigger_Click,
		// Token: 0x040004E5 RID: 1253
		XBoxOne_RightTrigger_Pull,
		// Token: 0x040004E6 RID: 1254
		XBoxOne_RightTrigger_Click,
		// Token: 0x040004E7 RID: 1255
		XBoxOne_LeftStick_Move,
		// Token: 0x040004E8 RID: 1256
		XBoxOne_LeftStick_Click,
		// Token: 0x040004E9 RID: 1257
		XBoxOne_LeftStick_DPadNorth,
		// Token: 0x040004EA RID: 1258
		XBoxOne_LeftStick_DPadSouth,
		// Token: 0x040004EB RID: 1259
		XBoxOne_LeftStick_DPadWest,
		// Token: 0x040004EC RID: 1260
		XBoxOne_LeftStick_DPadEast,
		// Token: 0x040004ED RID: 1261
		XBoxOne_RightStick_Move,
		// Token: 0x040004EE RID: 1262
		XBoxOne_RightStick_Click,
		// Token: 0x040004EF RID: 1263
		XBoxOne_RightStick_DPadNorth,
		// Token: 0x040004F0 RID: 1264
		XBoxOne_RightStick_DPadSouth,
		// Token: 0x040004F1 RID: 1265
		XBoxOne_RightStick_DPadWest,
		// Token: 0x040004F2 RID: 1266
		XBoxOne_RightStick_DPadEast,
		// Token: 0x040004F3 RID: 1267
		XBoxOne_DPad_North,
		// Token: 0x040004F4 RID: 1268
		XBoxOne_DPad_South,
		// Token: 0x040004F5 RID: 1269
		XBoxOne_DPad_West,
		// Token: 0x040004F6 RID: 1270
		XBoxOne_DPad_East,
		// Token: 0x040004F7 RID: 1271
		XBoxOne_DPad_Move,
		// Token: 0x040004F8 RID: 1272
		XBoxOne_LeftGrip_Lower,
		// Token: 0x040004F9 RID: 1273
		XBoxOne_LeftGrip_Upper,
		// Token: 0x040004FA RID: 1274
		XBoxOne_RightGrip_Lower,
		// Token: 0x040004FB RID: 1275
		XBoxOne_RightGrip_Upper,
		// Token: 0x040004FC RID: 1276
		XBoxOne_Share,
		// Token: 0x040004FD RID: 1277
		XBoxOne_Reserved6,
		// Token: 0x040004FE RID: 1278
		XBoxOne_Reserved7,
		// Token: 0x040004FF RID: 1279
		XBoxOne_Reserved8,
		// Token: 0x04000500 RID: 1280
		XBoxOne_Reserved9,
		// Token: 0x04000501 RID: 1281
		XBoxOne_Reserved10,
		// Token: 0x04000502 RID: 1282
		XBox360_A,
		// Token: 0x04000503 RID: 1283
		XBox360_B,
		// Token: 0x04000504 RID: 1284
		XBox360_X,
		// Token: 0x04000505 RID: 1285
		XBox360_Y,
		// Token: 0x04000506 RID: 1286
		XBox360_LeftBumper,
		// Token: 0x04000507 RID: 1287
		XBox360_RightBumper,
		// Token: 0x04000508 RID: 1288
		XBox360_Start,
		// Token: 0x04000509 RID: 1289
		XBox360_Back,
		// Token: 0x0400050A RID: 1290
		XBox360_LeftTrigger_Pull,
		// Token: 0x0400050B RID: 1291
		XBox360_LeftTrigger_Click,
		// Token: 0x0400050C RID: 1292
		XBox360_RightTrigger_Pull,
		// Token: 0x0400050D RID: 1293
		XBox360_RightTrigger_Click,
		// Token: 0x0400050E RID: 1294
		XBox360_LeftStick_Move,
		// Token: 0x0400050F RID: 1295
		XBox360_LeftStick_Click,
		// Token: 0x04000510 RID: 1296
		XBox360_LeftStick_DPadNorth,
		// Token: 0x04000511 RID: 1297
		XBox360_LeftStick_DPadSouth,
		// Token: 0x04000512 RID: 1298
		XBox360_LeftStick_DPadWest,
		// Token: 0x04000513 RID: 1299
		XBox360_LeftStick_DPadEast,
		// Token: 0x04000514 RID: 1300
		XBox360_RightStick_Move,
		// Token: 0x04000515 RID: 1301
		XBox360_RightStick_Click,
		// Token: 0x04000516 RID: 1302
		XBox360_RightStick_DPadNorth,
		// Token: 0x04000517 RID: 1303
		XBox360_RightStick_DPadSouth,
		// Token: 0x04000518 RID: 1304
		XBox360_RightStick_DPadWest,
		// Token: 0x04000519 RID: 1305
		XBox360_RightStick_DPadEast,
		// Token: 0x0400051A RID: 1306
		XBox360_DPad_North,
		// Token: 0x0400051B RID: 1307
		XBox360_DPad_South,
		// Token: 0x0400051C RID: 1308
		XBox360_DPad_West,
		// Token: 0x0400051D RID: 1309
		XBox360_DPad_East,
		// Token: 0x0400051E RID: 1310
		XBox360_DPad_Move,
		// Token: 0x0400051F RID: 1311
		XBox360_Reserved1,
		// Token: 0x04000520 RID: 1312
		XBox360_Reserved2,
		// Token: 0x04000521 RID: 1313
		XBox360_Reserved3,
		// Token: 0x04000522 RID: 1314
		XBox360_Reserved4,
		// Token: 0x04000523 RID: 1315
		XBox360_Reserved5,
		// Token: 0x04000524 RID: 1316
		XBox360_Reserved6,
		// Token: 0x04000525 RID: 1317
		XBox360_Reserved7,
		// Token: 0x04000526 RID: 1318
		XBox360_Reserved8,
		// Token: 0x04000527 RID: 1319
		XBox360_Reserved9,
		// Token: 0x04000528 RID: 1320
		XBox360_Reserved10,
		// Token: 0x04000529 RID: 1321
		Switch_A,
		// Token: 0x0400052A RID: 1322
		Switch_B,
		// Token: 0x0400052B RID: 1323
		Switch_X,
		// Token: 0x0400052C RID: 1324
		Switch_Y,
		// Token: 0x0400052D RID: 1325
		Switch_LeftBumper,
		// Token: 0x0400052E RID: 1326
		Switch_RightBumper,
		// Token: 0x0400052F RID: 1327
		Switch_Plus,
		// Token: 0x04000530 RID: 1328
		Switch_Minus,
		// Token: 0x04000531 RID: 1329
		Switch_Capture,
		// Token: 0x04000532 RID: 1330
		Switch_LeftTrigger_Pull,
		// Token: 0x04000533 RID: 1331
		Switch_LeftTrigger_Click,
		// Token: 0x04000534 RID: 1332
		Switch_RightTrigger_Pull,
		// Token: 0x04000535 RID: 1333
		Switch_RightTrigger_Click,
		// Token: 0x04000536 RID: 1334
		Switch_LeftStick_Move,
		// Token: 0x04000537 RID: 1335
		Switch_LeftStick_Click,
		// Token: 0x04000538 RID: 1336
		Switch_LeftStick_DPadNorth,
		// Token: 0x04000539 RID: 1337
		Switch_LeftStick_DPadSouth,
		// Token: 0x0400053A RID: 1338
		Switch_LeftStick_DPadWest,
		// Token: 0x0400053B RID: 1339
		Switch_LeftStick_DPadEast,
		// Token: 0x0400053C RID: 1340
		Switch_RightStick_Move,
		// Token: 0x0400053D RID: 1341
		Switch_RightStick_Click,
		// Token: 0x0400053E RID: 1342
		Switch_RightStick_DPadNorth,
		// Token: 0x0400053F RID: 1343
		Switch_RightStick_DPadSouth,
		// Token: 0x04000540 RID: 1344
		Switch_RightStick_DPadWest,
		// Token: 0x04000541 RID: 1345
		Switch_RightStick_DPadEast,
		// Token: 0x04000542 RID: 1346
		Switch_DPad_North,
		// Token: 0x04000543 RID: 1347
		Switch_DPad_South,
		// Token: 0x04000544 RID: 1348
		Switch_DPad_West,
		// Token: 0x04000545 RID: 1349
		Switch_DPad_East,
		// Token: 0x04000546 RID: 1350
		Switch_ProGyro_Move,
		// Token: 0x04000547 RID: 1351
		Switch_ProGyro_Pitch,
		// Token: 0x04000548 RID: 1352
		Switch_ProGyro_Yaw,
		// Token: 0x04000549 RID: 1353
		Switch_ProGyro_Roll,
		// Token: 0x0400054A RID: 1354
		Switch_DPad_Move,
		// Token: 0x0400054B RID: 1355
		Switch_Reserved1,
		// Token: 0x0400054C RID: 1356
		Switch_Reserved2,
		// Token: 0x0400054D RID: 1357
		Switch_Reserved3,
		// Token: 0x0400054E RID: 1358
		Switch_Reserved4,
		// Token: 0x0400054F RID: 1359
		Switch_Reserved5,
		// Token: 0x04000550 RID: 1360
		Switch_Reserved6,
		// Token: 0x04000551 RID: 1361
		Switch_Reserved7,
		// Token: 0x04000552 RID: 1362
		Switch_Reserved8,
		// Token: 0x04000553 RID: 1363
		Switch_Reserved9,
		// Token: 0x04000554 RID: 1364
		Switch_Reserved10,
		// Token: 0x04000555 RID: 1365
		Switch_RightGyro_Move,
		// Token: 0x04000556 RID: 1366
		Switch_RightGyro_Pitch,
		// Token: 0x04000557 RID: 1367
		Switch_RightGyro_Yaw,
		// Token: 0x04000558 RID: 1368
		Switch_RightGyro_Roll,
		// Token: 0x04000559 RID: 1369
		Switch_LeftGyro_Move,
		// Token: 0x0400055A RID: 1370
		Switch_LeftGyro_Pitch,
		// Token: 0x0400055B RID: 1371
		Switch_LeftGyro_Yaw,
		// Token: 0x0400055C RID: 1372
		Switch_LeftGyro_Roll,
		// Token: 0x0400055D RID: 1373
		Switch_LeftGrip_Lower,
		// Token: 0x0400055E RID: 1374
		Switch_LeftGrip_Upper,
		// Token: 0x0400055F RID: 1375
		Switch_RightGrip_Lower,
		// Token: 0x04000560 RID: 1376
		Switch_RightGrip_Upper,
		// Token: 0x04000561 RID: 1377
		Switch_Reserved11,
		// Token: 0x04000562 RID: 1378
		Switch_Reserved12,
		// Token: 0x04000563 RID: 1379
		Switch_Reserved13,
		// Token: 0x04000564 RID: 1380
		Switch_Reserved14,
		// Token: 0x04000565 RID: 1381
		Switch_Reserved15,
		// Token: 0x04000566 RID: 1382
		Switch_Reserved16,
		// Token: 0x04000567 RID: 1383
		Switch_Reserved17,
		// Token: 0x04000568 RID: 1384
		Switch_Reserved18,
		// Token: 0x04000569 RID: 1385
		Switch_Reserved19,
		// Token: 0x0400056A RID: 1386
		Switch_Reserved20,
		// Token: 0x0400056B RID: 1387
		PS5_X,
		// Token: 0x0400056C RID: 1388
		PS5_Circle,
		// Token: 0x0400056D RID: 1389
		PS5_Triangle,
		// Token: 0x0400056E RID: 1390
		PS5_Square,
		// Token: 0x0400056F RID: 1391
		PS5_LeftBumper,
		// Token: 0x04000570 RID: 1392
		PS5_RightBumper,
		// Token: 0x04000571 RID: 1393
		PS5_Option,
		// Token: 0x04000572 RID: 1394
		PS5_Create,
		// Token: 0x04000573 RID: 1395
		PS5_Mute,
		// Token: 0x04000574 RID: 1396
		PS5_LeftPad_Touch,
		// Token: 0x04000575 RID: 1397
		PS5_LeftPad_Swipe,
		// Token: 0x04000576 RID: 1398
		PS5_LeftPad_Click,
		// Token: 0x04000577 RID: 1399
		PS5_LeftPad_DPadNorth,
		// Token: 0x04000578 RID: 1400
		PS5_LeftPad_DPadSouth,
		// Token: 0x04000579 RID: 1401
		PS5_LeftPad_DPadWest,
		// Token: 0x0400057A RID: 1402
		PS5_LeftPad_DPadEast,
		// Token: 0x0400057B RID: 1403
		PS5_RightPad_Touch,
		// Token: 0x0400057C RID: 1404
		PS5_RightPad_Swipe,
		// Token: 0x0400057D RID: 1405
		PS5_RightPad_Click,
		// Token: 0x0400057E RID: 1406
		PS5_RightPad_DPadNorth,
		// Token: 0x0400057F RID: 1407
		PS5_RightPad_DPadSouth,
		// Token: 0x04000580 RID: 1408
		PS5_RightPad_DPadWest,
		// Token: 0x04000581 RID: 1409
		PS5_RightPad_DPadEast,
		// Token: 0x04000582 RID: 1410
		PS5_CenterPad_Touch,
		// Token: 0x04000583 RID: 1411
		PS5_CenterPad_Swipe,
		// Token: 0x04000584 RID: 1412
		PS5_CenterPad_Click,
		// Token: 0x04000585 RID: 1413
		PS5_CenterPad_DPadNorth,
		// Token: 0x04000586 RID: 1414
		PS5_CenterPad_DPadSouth,
		// Token: 0x04000587 RID: 1415
		PS5_CenterPad_DPadWest,
		// Token: 0x04000588 RID: 1416
		PS5_CenterPad_DPadEast,
		// Token: 0x04000589 RID: 1417
		PS5_LeftTrigger_Pull,
		// Token: 0x0400058A RID: 1418
		PS5_LeftTrigger_Click,
		// Token: 0x0400058B RID: 1419
		PS5_RightTrigger_Pull,
		// Token: 0x0400058C RID: 1420
		PS5_RightTrigger_Click,
		// Token: 0x0400058D RID: 1421
		PS5_LeftStick_Move,
		// Token: 0x0400058E RID: 1422
		PS5_LeftStick_Click,
		// Token: 0x0400058F RID: 1423
		PS5_LeftStick_DPadNorth,
		// Token: 0x04000590 RID: 1424
		PS5_LeftStick_DPadSouth,
		// Token: 0x04000591 RID: 1425
		PS5_LeftStick_DPadWest,
		// Token: 0x04000592 RID: 1426
		PS5_LeftStick_DPadEast,
		// Token: 0x04000593 RID: 1427
		PS5_RightStick_Move,
		// Token: 0x04000594 RID: 1428
		PS5_RightStick_Click,
		// Token: 0x04000595 RID: 1429
		PS5_RightStick_DPadNorth,
		// Token: 0x04000596 RID: 1430
		PS5_RightStick_DPadSouth,
		// Token: 0x04000597 RID: 1431
		PS5_RightStick_DPadWest,
		// Token: 0x04000598 RID: 1432
		PS5_RightStick_DPadEast,
		// Token: 0x04000599 RID: 1433
		PS5_DPad_North,
		// Token: 0x0400059A RID: 1434
		PS5_DPad_South,
		// Token: 0x0400059B RID: 1435
		PS5_DPad_West,
		// Token: 0x0400059C RID: 1436
		PS5_DPad_East,
		// Token: 0x0400059D RID: 1437
		PS5_Gyro_Move,
		// Token: 0x0400059E RID: 1438
		PS5_Gyro_Pitch,
		// Token: 0x0400059F RID: 1439
		PS5_Gyro_Yaw,
		// Token: 0x040005A0 RID: 1440
		PS5_Gyro_Roll,
		// Token: 0x040005A1 RID: 1441
		PS5_DPad_Move,
		// Token: 0x040005A2 RID: 1442
		PS5_Reserved1,
		// Token: 0x040005A3 RID: 1443
		PS5_Reserved2,
		// Token: 0x040005A4 RID: 1444
		PS5_Reserved3,
		// Token: 0x040005A5 RID: 1445
		PS5_Reserved4,
		// Token: 0x040005A6 RID: 1446
		PS5_Reserved5,
		// Token: 0x040005A7 RID: 1447
		PS5_Reserved6,
		// Token: 0x040005A8 RID: 1448
		PS5_Reserved7,
		// Token: 0x040005A9 RID: 1449
		PS5_Reserved8,
		// Token: 0x040005AA RID: 1450
		PS5_Reserved9,
		// Token: 0x040005AB RID: 1451
		PS5_Reserved10,
		// Token: 0x040005AC RID: 1452
		PS5_Reserved11,
		// Token: 0x040005AD RID: 1453
		PS5_Reserved12,
		// Token: 0x040005AE RID: 1454
		PS5_Reserved13,
		// Token: 0x040005AF RID: 1455
		PS5_Reserved14,
		// Token: 0x040005B0 RID: 1456
		PS5_Reserved15,
		// Token: 0x040005B1 RID: 1457
		PS5_Reserved16,
		// Token: 0x040005B2 RID: 1458
		PS5_Reserved17,
		// Token: 0x040005B3 RID: 1459
		PS5_Reserved18,
		// Token: 0x040005B4 RID: 1460
		PS5_Reserved19,
		// Token: 0x040005B5 RID: 1461
		PS5_Reserved20,
		// Token: 0x040005B6 RID: 1462
		SteamDeck_A,
		// Token: 0x040005B7 RID: 1463
		SteamDeck_B,
		// Token: 0x040005B8 RID: 1464
		SteamDeck_X,
		// Token: 0x040005B9 RID: 1465
		SteamDeck_Y,
		// Token: 0x040005BA RID: 1466
		SteamDeck_L1,
		// Token: 0x040005BB RID: 1467
		SteamDeck_R1,
		// Token: 0x040005BC RID: 1468
		SteamDeck_Menu,
		// Token: 0x040005BD RID: 1469
		SteamDeck_View,
		// Token: 0x040005BE RID: 1470
		SteamDeck_LeftPad_Touch,
		// Token: 0x040005BF RID: 1471
		SteamDeck_LeftPad_Swipe,
		// Token: 0x040005C0 RID: 1472
		SteamDeck_LeftPad_Click,
		// Token: 0x040005C1 RID: 1473
		SteamDeck_LeftPad_DPadNorth,
		// Token: 0x040005C2 RID: 1474
		SteamDeck_LeftPad_DPadSouth,
		// Token: 0x040005C3 RID: 1475
		SteamDeck_LeftPad_DPadWest,
		// Token: 0x040005C4 RID: 1476
		SteamDeck_LeftPad_DPadEast,
		// Token: 0x040005C5 RID: 1477
		SteamDeck_RightPad_Touch,
		// Token: 0x040005C6 RID: 1478
		SteamDeck_RightPad_Swipe,
		// Token: 0x040005C7 RID: 1479
		SteamDeck_RightPad_Click,
		// Token: 0x040005C8 RID: 1480
		SteamDeck_RightPad_DPadNorth,
		// Token: 0x040005C9 RID: 1481
		SteamDeck_RightPad_DPadSouth,
		// Token: 0x040005CA RID: 1482
		SteamDeck_RightPad_DPadWest,
		// Token: 0x040005CB RID: 1483
		SteamDeck_RightPad_DPadEast,
		// Token: 0x040005CC RID: 1484
		SteamDeck_L2_SoftPull,
		// Token: 0x040005CD RID: 1485
		SteamDeck_L2,
		// Token: 0x040005CE RID: 1486
		SteamDeck_R2_SoftPull,
		// Token: 0x040005CF RID: 1487
		SteamDeck_R2,
		// Token: 0x040005D0 RID: 1488
		SteamDeck_LeftStick_Move,
		// Token: 0x040005D1 RID: 1489
		SteamDeck_L3,
		// Token: 0x040005D2 RID: 1490
		SteamDeck_LeftStick_DPadNorth,
		// Token: 0x040005D3 RID: 1491
		SteamDeck_LeftStick_DPadSouth,
		// Token: 0x040005D4 RID: 1492
		SteamDeck_LeftStick_DPadWest,
		// Token: 0x040005D5 RID: 1493
		SteamDeck_LeftStick_DPadEast,
		// Token: 0x040005D6 RID: 1494
		SteamDeck_LeftStick_Touch,
		// Token: 0x040005D7 RID: 1495
		SteamDeck_RightStick_Move,
		// Token: 0x040005D8 RID: 1496
		SteamDeck_R3,
		// Token: 0x040005D9 RID: 1497
		SteamDeck_RightStick_DPadNorth,
		// Token: 0x040005DA RID: 1498
		SteamDeck_RightStick_DPadSouth,
		// Token: 0x040005DB RID: 1499
		SteamDeck_RightStick_DPadWest,
		// Token: 0x040005DC RID: 1500
		SteamDeck_RightStick_DPadEast,
		// Token: 0x040005DD RID: 1501
		SteamDeck_RightStick_Touch,
		// Token: 0x040005DE RID: 1502
		SteamDeck_L4,
		// Token: 0x040005DF RID: 1503
		SteamDeck_R4,
		// Token: 0x040005E0 RID: 1504
		SteamDeck_L5,
		// Token: 0x040005E1 RID: 1505
		SteamDeck_R5,
		// Token: 0x040005E2 RID: 1506
		SteamDeck_DPad_Move,
		// Token: 0x040005E3 RID: 1507
		SteamDeck_DPad_North,
		// Token: 0x040005E4 RID: 1508
		SteamDeck_DPad_South,
		// Token: 0x040005E5 RID: 1509
		SteamDeck_DPad_West,
		// Token: 0x040005E6 RID: 1510
		SteamDeck_DPad_East,
		// Token: 0x040005E7 RID: 1511
		SteamDeck_Gyro_Move,
		// Token: 0x040005E8 RID: 1512
		SteamDeck_Gyro_Pitch,
		// Token: 0x040005E9 RID: 1513
		SteamDeck_Gyro_Yaw,
		// Token: 0x040005EA RID: 1514
		SteamDeck_Gyro_Roll,
		// Token: 0x040005EB RID: 1515
		SteamDeck_Reserved1,
		// Token: 0x040005EC RID: 1516
		SteamDeck_Reserved2,
		// Token: 0x040005ED RID: 1517
		SteamDeck_Reserved3,
		// Token: 0x040005EE RID: 1518
		SteamDeck_Reserved4,
		// Token: 0x040005EF RID: 1519
		SteamDeck_Reserved5,
		// Token: 0x040005F0 RID: 1520
		SteamDeck_Reserved6,
		// Token: 0x040005F1 RID: 1521
		SteamDeck_Reserved7,
		// Token: 0x040005F2 RID: 1522
		SteamDeck_Reserved8,
		// Token: 0x040005F3 RID: 1523
		SteamDeck_Reserved9,
		// Token: 0x040005F4 RID: 1524
		SteamDeck_Reserved10,
		// Token: 0x040005F5 RID: 1525
		SteamDeck_Reserved11,
		// Token: 0x040005F6 RID: 1526
		SteamDeck_Reserved12,
		// Token: 0x040005F7 RID: 1527
		SteamDeck_Reserved13,
		// Token: 0x040005F8 RID: 1528
		SteamDeck_Reserved14,
		// Token: 0x040005F9 RID: 1529
		SteamDeck_Reserved15,
		// Token: 0x040005FA RID: 1530
		SteamDeck_Reserved16,
		// Token: 0x040005FB RID: 1531
		SteamDeck_Reserved17,
		// Token: 0x040005FC RID: 1532
		SteamDeck_Reserved18,
		// Token: 0x040005FD RID: 1533
		SteamDeck_Reserved19,
		// Token: 0x040005FE RID: 1534
		SteamDeck_Reserved20,
		// Token: 0x040005FF RID: 1535
		Count,
		// Token: 0x04000600 RID: 1536
		MaximumPossibleValue = 32767
	}
}
