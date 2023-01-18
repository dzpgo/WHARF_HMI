#! /bin/bash
#rm -rf /backup/db2backup1/*
#mv /backup/db2backup/* /backup/db2backup1/
dbname=uacsdb0
dbuser=db2inst1
dblocalbackuppath=/localbackup/
dblocalarchpath=/localbackup/db2/arch
#dbmsaarchpath1=/db2data/arch1
#dbmsaarchpath2=/db2data/arch2

# backup db
su - db2inst1 -c "db2 backup database $dbname online to $dblocalbackuppath include logs;"

# delete expired db backup
find $dblocalbackuppath -type f -mtime +6 -exec rm -f {} \;

# delete expired db arch
#find $dbmsaarchpath1 -type f -mtime +2 -exec rm -f {} \;
#find $dbmsaarchpath2 -type f -mtime +2 -exec rm -f {} \;

find $dblocalarchpath -type f -mtime +6 -exec rm -f {} \;