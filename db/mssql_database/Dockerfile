FROM mcr.microsoft.com/mssql/server

USER root

COPY setup.sql setup.sql
COPY setup_database.sh setup_database.sh
COPY entrypoint.sh entrypoint.sh

CMD /bin/bash ./entrypoint.sh

EXPOSE 1433