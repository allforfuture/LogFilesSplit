for /f %%a in ('cscript //nologo getyesterday.vbs') do set tday=%%a
echo %tday%
md D:\kk08_bk\%tday%
move D:\public_kk08\*%tday%*.csv D:\kk08_bk\%tday%

md D:\kk09_bk\%tday%
move D:\public_kk09\*%tday%*.csv D:\kk09_bk\%tday%