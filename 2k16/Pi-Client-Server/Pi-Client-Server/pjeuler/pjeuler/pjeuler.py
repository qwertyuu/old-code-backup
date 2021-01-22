laliste = range(1000000)
for i in laliste:
    if(not(i == 0 or i == 1)):
        for n in xrange(i + i, len(laliste), i):
            laliste[n] = 0
count = -1
for i in laliste:
    if(i!=0):
        count += 1
    if(count == 10001):
        print(i, count)
        break
else:
    print "Fail", count

print "nope"
raw_input()