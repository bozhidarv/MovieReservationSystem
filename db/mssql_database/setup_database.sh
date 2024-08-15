#!/usr/bin/env bash
# Wait for database to startup 
# for i in {1..50};
# do
#     /opt/mssql-tools18/bin/sqlcmd -S localhost,1433 -U sa -P MssqlPass1! -d master -C -i setup.sql
#     if [ $? -eq 0 ]
#     then
#         echo "setup.sql completed"
#         break
#     else
#         echo "not ready yet... ${i}"
#         sleep 1
#     fi
# done

sleep 20
/opt/mssql-tools18/bin/sqlcmd -S localhost,1433 -U sa -P MssqlPass1! -d master -C -i setup.sql