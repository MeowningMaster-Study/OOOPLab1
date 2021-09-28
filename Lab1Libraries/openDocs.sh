#!/bin/sh
BASEDIR=$(dirname $0)
cd ${BASEDIR}
pwd

docfx docfx.json --serve &
start http://localhost:8080/
read -p "Press any key to continue" x