# WakeOnLan (WOL)

The get help run the application with --help:

$> WOL --help
```
WOL 1.0.1
Copyright (C) 2022 WOL

  -m, --mac-address    Required. MAC addresses to send Wake On Lan packet to. Seperate addresses with a space.

  -p, --port           The UDP port to use to send the magic packet. Default 12287.

  --help               Display this help screen.

  --version            Display version information.
  ```
  
#Examples
  
$> WOL -p 12345 -m AA:BB:CC:DD:EE:FF 11-22-33-44-55-66 778899AABBCC INVALIDMAC aa:11-22ff8a-00
```
Wake up AA:BB:CC:DD:EE:FF successfull.
Wake up 11-22-33-44-55-66 successfull.
Wake up 778899AABBCC successfull.
Mac address must contain 6 x HEX pairs, skipping. This mac is incorrect: INVALIDMAC
Wake up aa:11-22ff8a-00 successfull.
```
