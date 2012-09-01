cd \
move C:\mongodb-win32-x86_64-2.0.7 C:\mongodb
md data
md data\db
md C:\mongodb\log
echo logpath=C:\mongodb\log\mongo.log > C:\mongodb\mongod.cfg
C:\mongodb\bin\mongod.exe --config C:\mongodb\mongod.cfg -- install
net start MongoDB