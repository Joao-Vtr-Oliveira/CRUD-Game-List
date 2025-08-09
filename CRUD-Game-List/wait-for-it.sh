#!/usr/bin/env bash
set -e

host="$1"
shift
port="$1"
shift

echo "Esperando $host:$port ficar pronto..."

while ! nc -z "$host" "$port"; do
  sleep 1
done

echo "$host:$port está pronto!"
exec "$@"
