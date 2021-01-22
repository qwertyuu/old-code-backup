import time
debut = time.clock()
for i in range(100):
    max = 0
    for multiple1 in range(1, 1000):
        for multiple2 in range(multiple1, 1000):
            val = multiple1 * multiple2
            shit = str(val)
            if shit == shit[::-1] and val > max:
                    max = val
    print i, time.clock() - debut
print max
print time.clock() - debut
raw_input()