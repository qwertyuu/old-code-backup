import random
import datetime

def convert(a):
   multiplier = 128
   toReturn = 0
   for c in a:
       buf = int(c)
       if buf==1:
           toReturn+=multiplier
       multiplier /= 2
   return toReturn
while True:
    currentTime = datetime.datetime.now()
    for y in range(10):
        yolo = ""
        for x in range(8):
            yolo += str(random.randint(0,1))
        print yolo, ':', convert(yolo)
    print (datetime.datetime.now() - currentTime)
    raw_input() 
