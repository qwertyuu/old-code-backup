# -*- coding: utf-8 -*-
import socket, time
host = ''
port = 80
backlog = 5
size = 1024
s = socket.socket()
s.bind((host,port))
s.listen(backlog)
MIMEFile = open('MIME.txt', 'r')
MIMELines = MIMEFile.readlines()
extensions = {}
for MIMELine in MIMELines:
    prefix, suffix = MIMELine.split('\t')
    extensions[prefix.strip()] = suffix.strip()

print 'ready'

while 1:
    client, address = s.accept()
    client.setblocking(0)

    try:
        time.sleep(0.01)
        msg = client.recv(1024)
        print msg
        parties = msg.split('\r\n')
        leGET = parties[0].replace('GET ', '').replace('HTTP/1.1', '').strip()
        path = 'public_html' + leGET
        if path[-1] == '/':
            path += 'index.html'
        MIME = 'text/text'
        extension = path[path.rfind('.'):]
        if '.' in path and extension in extensions:
            MIME = extensions[extension]
        
        try:
            fichier = open(path, 'rb')
            fichier.seek(0, 2)
            reponse = 'HTTP/1.1 200 OK\r\nContent-Type: ' + MIME + '; charset=UTF-8\r\nContent-Length: ' + str(fichier.tell()) + '\r\n\r\n'
            fichier.seek(0, 0)
            client.send(reponse)
            print reponse
            while 1:
                buf = fichier.read()
                if buf == '': break
                client.send(buf)
                fichier.flush()
        except IOError as e:
            print e
            fichier = open('public_html/404/404.html', 'rb')
            fichier.seek(0, 2)
            reponse = 'HTTP/1.1 404 Not Found\r\nContent-Type: text/html; charset=UTF-8\r\nContent-Length: ' + str(fichier.tell()) + '\r\n\r\n'
            fichier.seek(0, 0)
            client.send(reponse)
            print reponse
            while 1:
                buf = fichier.read()
                if buf == '': break
                client.send(buf)
                fichier.flush()

        client.close()
        time.sleep(0.2)

    except socket.error as err:
        print err.message
        pass