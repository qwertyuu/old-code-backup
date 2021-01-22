import socket, atexit
print "Press enter to start connection"
raw_input()
host = '192.168.1.16'
port = 50001
size = 1024
s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.connect((host,port))
def closeThis():
    s.send("/exit")
    s.close()

atexit.register(closeThis)

while 1:
    try:
        data = s.recv(size)
        print 'Received:', data
    except KeyboardInterrupt:
        closeThis()
        break

print "Connection ended"
