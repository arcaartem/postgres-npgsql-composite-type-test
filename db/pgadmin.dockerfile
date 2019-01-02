FROM dpage/pgadmin4:3.6

WORKDIR /
COPY config_local.py .
COPY pgadmin4.db ./var/lib/pgadmin/
