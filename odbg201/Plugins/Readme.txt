
== Files
- OllyMigrate_Od11.dll
  for OllyDbg version 1.10 (1.10 tested)
- OllyMigrate_Od20.dll
  for OllyDbg version 2.01 (2.01 tested)
- OllyMigrate_Imm18.dll
  for Immunity Debugger version 1.8x or higher (1.85 tested)
- OllyMigrate_IdaRT.plw, OllyMigrate_IdaRT.p64
  for IDA Pro Retail version 5.0 or higher (6.6 tested)
- OllyMigrate_IdaFW.plw
  for IDA Pro Freeware version 5.0 (5.0 tested)
- OllyMigrate_Wd32.dll, OllyMigrate_Wd64.dll
  for WinDbg version 6.x (6.2 tested)
- OllyMigrate_X64Dbg.dp32, OllyMigrate_X64Dbg.dp64
  for x64dbg (v25 tested)


== How to use (OllyDbg example)
- Step 1 
  Install "same version" plugin to sender(src) and receiver(dst) debuggers.
- Step 2 
  Start sender debugger to add receiver debugger definition.
  Menu > Plugins > OllyMigrate > Options
  Input debugger info
   Path: receiver debugger path (Click [Browse] and select file)
   Tag:  anything is ok (identification only)
   Args: debugger command line argument (usually not need to change)
  Click [Add] and [Save]
- Step 3
  Open debuggee using sender debugger. Start debugging (e.g. until detect OEP)
  After that switch to another debugger. Paused status is recommended.
   Menu > Plugins > OllyMigrate > Send Debuggee
  Select destination debugger and Click [Migrate]
- Step 4
  Receiver debugger startup automatically and receive debuggee.
  Continue debugging.

  
== Known Issue
- Receive or Send migration failed (stalled)
  OllyDbg2:
    Pause on System breakpoint and Application code not supported.
    Change following OllyDbg config.
    Menu > Options > Debugging > Start
     When attaching to application, make first pause at: "No pause"
  All Debuggers:
    "Break on new thread" and "Break on exit thread" features
    conflict with migration.
- Cannot migrate hardware and memory breakpoint
  Currently support software breakpoint(INT3) only.
  Others will be removed.
- Receive debuggee with existing idb file (IDA Pro)
  Append idb file path to debugger args. (e.g. -rwin32+%PID% "idb_path")
  Drag and drop available to copy idb file path to args. (except IDA Pro and x64dbg)
  But WinDbg debugger backend require "Suspend on thread start/exit" config.
   Debugger > Debugger Options > "Suspend on thread start/exit" set On
  Otherwise, send and receive manually after open idb and attach.
- IDA Pro limitation
  Local Win32 debugger and WinDbg are supported.
  Manual receive failed using WinDbg backend, Retry after press F8 once.
  Cannot collect break-in thread for pause process when sending.
  Disabled breakpoint status ignored when sending. (<6.3)
  Cannot handle dropfile event. (Qt issue)
- WinDbg limitation
  Migrate cpu window state not supported.
  Cannot collect break-in thread for pause process when sending.
- x64dbg limitation
  Cannot handle dropfile event. (Qt issue)
- Common 64bit limitation
  WOW64 process migration on 64bit debugger is not stable, use 32bit debugger.


== Changelog
- v0.91 / 2016-08-29
  Improve: Support recent version of x64dbg (v25)
  Del: Drop old version of Immunity Debugger support (1.7x)
- v0.90 / 2014-12-17
  Add: Support x64dbg plugin interface
  Add: Support native 64bit process migration (IDA Pro, WinDbg, x64dbg)
  Improve: Enable NXCOMPAT and DYNAMICBASE for plugin binaries
- v0.80 / 2013-06-22
  Add: Support IDA Pro with WinDbg debugger backend
  Add: Support WinDbg plugin interface
  Improve: Migrate cpu window state (disassemble, dump, stack)
  Improve: Remove button behavior and add Up/Down button on options dialog 
  Improve: Debugger args editable when sending (for append idb file path)
  Improve: Improve migration stability (OllyDbg1, Immunity)
  Bugfix: Exit debugger option not work (recent version of IDA Pro)
- v0.70 / 2013-04-30
  Add: Support IDA Pro plugin interface (both Retail and Freeware version)
  Add: Exit debugger option (OllyDbg2 and IDA Pro only)
  Improve: Enter key behavior on options dialog
  Improve: Debugger arguments auto detect
  Improve: Change dialog position to center of parent window 
  Improve: Add debug toggle menu to dialog system menu
  Bugfix: Empty arguments rejected
- v0.60 / 2013-04-13
  Public release version
- v0.50
  Improve: Add OllyDbg2 incompatible pause on attach config warning
  Bugfix: OllyDbg2 fail to receive break point
- v0.40
  Add: Configuration interface (Options)
  Improve: Update to OllyDbg 2 latest version PDK
  Improve: Improve migration stability
- v0.30
  Add: OllyDbg2 support
  Bugfix: Fix many bugs
- v0.20
  Add: Support Immunity Debugger
  Add: Add many features
- v0.10
  Initial version


== Bug Report
  Please try latest version before report. 
  With your environment detail, logs and way to reproduce.
   WEB:  http://low-priority.appspot.com/ollymigrate/
   MAIL: lowprio20/_at_/gmail/_dot_/com
