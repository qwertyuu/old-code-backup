import os, copy, time, random
state = []

def clear():
    os.system('cls')

def print_board(printable):
    for i in printable:
        print ''.join(make_string(i))

def make_string(array):
    string = ''
    for i in array:
        string += '#' if i else ' '
    return string

def init_board():
    initialable = []
    for i in range(24):
        initialable.append([])
        for j in range(79):
            lerandome = random.randint(0,1)
            if lerandome:
                state.append((int(i), int(j)))
            initialable[i].append(lerandome)
    return initialable

def next_gen(original):
    newgen = copy.deepcopy(original)
    global state
    newstate = copy.deepcopy(state)
    around = {}
    for i in range(len(state)):
        elementX = state[i][1]
        elementY = state[i][0]
        newgen[elementY][elementX] = all_around(elementX, elementY, original, around)
        if not newgen[elementY][elementX]:
            newstate.remove((elementY, elementX))
    for i in around:
        if around[i] == 3:
            newgen[i[0]][i[1]] = True
            newstate.append((i[0],i[1]))
    state = uniqify(newstate)
    return newgen

def uniqify(seq): 
    return list(set(seq))

def all_around(x, y, original, around):
    minx = miny = -1
    maxx = maxy = 2
    neighbors = 0
    for X in range(minx, maxx):
        bufx = X + x
        if bufx > 78:
            xpos = 0
        elif bufx < 0:
            xpos = 78
        else:
            xpos = bufx
        for Y in range(miny, maxy):
            bufy = Y+y
            if bufy > 23:
                ypos = 0
            elif bufy < 0:
                ypos = 23
            else:
                ypos = bufy
            if not (X == 0 and Y == 0):
                if original[ypos][xpos]:
                    neighbors += 1
                else:
                    increment(xpos,ypos, around)
    return neighbors >= 2 and neighbors <= 3

def increment(x, y, around):
    if (y, x) in around:
        around[(y,x)] += 1
    else:
        around[(y,x)] = 1

os.system('setterm -cursor off')
board = init_board()

for i in range(1500):
    clear()
    print_board(board)
    board = next_gen(board)