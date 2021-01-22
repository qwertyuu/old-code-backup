import socket
host = ''
port = 1900
s = socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
s.bind((host,port))

while 1:
    print s.recv(1024),