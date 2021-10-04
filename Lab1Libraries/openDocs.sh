#!/bin/sh
BASEDIR=$(dirname $0)
cd ${BASEDIR}
pwd

start http://localhost:8080/
docfx docfx.json --serve