; copy card title to the clipboard, remove [] prefix, turn spaces into _, paste it
#v:: ; win-v
ClipSave := Clipboard ; store current clipboard
ClipSave := RegExReplace(ClipSave, "\[.*\] ", "")
ClipSave := StrReplace(ClipSave, " ", "_")
Send %ClipSave%
ClipSave:="" ; clear variable
Return