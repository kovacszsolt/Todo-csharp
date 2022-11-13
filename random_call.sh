RANDOM_NUMBER=$(shuf -i 0-2 -n1)
URL='https://raNDOM.HOST'
CURRENTDATE=$(date +"%Y-%m-%d_%T")
DATA='{"data":"'$CURRENTDATE'"}'
echo $RANDOM_NUMBER
case $RANDOM_NUMBER in
0)
URL0=$URL'/data/getall'
wget $URL0 --no-verbose >/dev/null

;;
1)
URL1=$URL'/data'
wget -O- --post-data=$DATA --header='Content-Type:application/json' $URL1 
;;
2)
URL2=$URL'/data/getalldelay'
wget $URL2 --no-verbose>/dev/null
;;
esac
