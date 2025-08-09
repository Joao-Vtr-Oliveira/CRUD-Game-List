#!/usr/bin/env bash
set -e
HOST="$1"; PORT="$2"; shift 2
CMD="$@"

echo "Aguardando $HOST:$PORT..."
while ! (echo >/dev/tcp/$HOST/$PORT) >/dev/null 2>&1; do
  sleep 1
done
echo "$HOST:$PORT está disponível"
exec $CMD
