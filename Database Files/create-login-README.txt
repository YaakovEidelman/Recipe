script to create login and user is excluded from this repo.
Create a file called create-login.sql (this file is ignored by git ignore in this repo) and add 
the following to that file:

use master
go
create login [loginname] with password = '[password]'
go
use RecordKeeperDB
go
create user [username] from login [loginname]
