class Swag(object):
    def __init__(self):
        self._x = None
    def getx(self):
        return self._x
    def setx(self, value):
        self._x = value
    def delx(self):
        del self._x
    x = property(getx, setx, delx, "I'm the 'x' property.")
    y = property(None,None,None,"yes")

ray = []
test = []
for i in range(5):
    buf = Swag
    buf.hello = "Hello"
    buf.index = 5 - i
    ray.append(buf)
for i in range(len(array)):
    print ray[i].hello, ray[i].index
raw_input()