jack_dit = raw_input("Dit quelque chose, Jack: ")
retour = ""
for i in jack_dit:
    j = i.lower()
    if (j == 'a' or j == 'e' or j == 'i' or j == 'o' or j == 'u' or j == 'y' or j == ' '):
        retour += i

print "Sans les voyelles:", retour
raw_input()