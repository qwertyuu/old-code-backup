# -*- coding: utf-8 -*-
import socket, time, os, datetime
host = ''
port = 8888
backlog = 100
s = socket.socket()
s.bind((host,port))
s.listen(backlog)
MIMEFile = open('MIME.txt', 'r')
MIMELines = MIMEFile.readlines()
extensions = {}
for MIMELine in MIMELines:
    prefix, suffix = MIMELine.split('\t')
    extensions[prefix.strip()] = suffix.strip()

def timelapse(total, begin):
    temps = (datetime.datetime.now() - begin).total_seconds()
    return str(round(total / 1048576.0, 2)) + 'mB > ' + str(round(total / temps / 1048576.0, 2)) + 'mB/s ' + '(' + str(temps) + 's)'

class Header:
    def __init__(self, message):
        parties = message.split('\r\n')
        try:
            type, fichier, version = parties[0].split(' ')
        except ValueError as ve:
            print 'erreur split.'
            print "'" + message + "' " + len(message) 
            print ve
            type = 'GET'
            fichier = '/'
            version = 'HTTP/1.1'
        self.type = type
        self.fichier = fichier
        self.version = version
        self.value = ''
        self.param = {}
        passe = False
        for ligne in parties[1:]:
            if passe:
                self.value += ligne
            else:
                if ligne.strip() == '':
                    passe = True
                    continue
                nom, valeur = ligne.split(': ')
                self.param[nom] = valeur

    def AddValue(self, value):
        self.value += value
print 'allo git'

while 1:
    client, address = s.accept()

    try:
        #time.sleep(0.01)
        rawmsg = client.recv(1024)
        msg = rawmsg.strip()

    except socket.error as err:
        print err.message

    if msg and len(msg) == 0:
        continue
    Entete = Header(msg)
    print 'Type:', Entete.type
    print 'Path:', Entete.fichier
    if Entete.type == 'POST':
        print 'Value: ' + str(len(Entete.value)) + 'B'
        for key, value in Entete.param.iteritems():
            print key + '->' + value
    if 'Content-Length' in Entete.param:
        transferrate = 1024
        waitingfor = int(Entete.param['Content-Length'])
        a = datetime.datetime.now()
        while waitingfor > len(Entete.value):
            try:
                msg = client.recv(transferrate)
            except socket.error as err:
                print err.message

            Entete.AddValue(msg)
            if transferrate < 1073741823:
                transferrate *= 2
            else:
                transferrate = 2147483647
        print 'recu:', timelapse(waitingfor, a)
        """
        ext = extensions.keys()[extensions.values().index(Entete.param['Content-Type'])]
        test = open('swig' + ext, 'wb')
        test.write(Entete.value)
        test.close()
        os.system('start swig' + ext)
        """


    path = 'public_html' + Entete.fichier
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
    except IOError as e:
        print e
        fichier = open('public_html/404/404.html', 'rb')
        fichier.seek(0, 2)
        reponse = 'HTTP/1.1 404 Not Found\r\nContent-Type: text/html; charset=UTF-8\r\nContent-Length: ' + str(fichier.tell()) + '\r\n\r\n'
        fichier.seek(0, 0)
        print reponse
    client.send(reponse)
    #print reponse
    lines = fichier.read()
    sending = len(lines)
    a = datetime.datetime.now()
    while lines:
        try:
            sent = client.send(lines)
        except IOError as e:
            print e
        lines = lines[sent:]
    print 'sent:', timelapse(sending, a)

    client.close()
    #time.sleep(0.05)
    print
