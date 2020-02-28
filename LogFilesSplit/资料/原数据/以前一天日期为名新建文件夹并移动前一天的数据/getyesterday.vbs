Option Explicit
Dim tday,ystr,mstr,dstr
tday = dateadd("d",-1,date)
ystr = year(tday)
mstr = month(tday)
if len(mstr) < 2 then mstr = "0"&mstr
dstr = day(tday)
if len(dstr) < 2 then dstr = "0"&dstr
tday = ystr&mstr&dstr
Wscript.echo tday