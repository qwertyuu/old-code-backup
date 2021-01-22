def primeFactors(number):
    primefactors = []
    copyOfInput = number
    i = 2
    while i <= copyOfInput:
        if copyOfInput % i == 0:
            primefactors.append(i)
            copyOfInput /= i
            i -= 1
        i += 1
    return primefactors

print str(primeFactors(13195))
raw_input()
