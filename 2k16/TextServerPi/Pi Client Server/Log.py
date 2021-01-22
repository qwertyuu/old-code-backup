import sys, os, datetime

class Logger(object):
    def __init__(self, fileName):
        self.name = fileName + ".log"
        self.file = self.OpenFile()
        self._Register()

    def _Register(self):
        import atexit
        atexit.register(self.CloseFile)

    def CloseFile(self):
        self.file.close()

    def OpenFile(self):
        try :
            f = open(self.name, 'a')
        except IOError:
            sys.stderr.write('Cannot open file: ' + self.name + '.txt.')
            sys.exit()

        return f

    def WriteToLog(self, msg):
        time = datetime.datetime.now().strftime("%d/%m/%y : %H:%M:%S")
        self.file.write(time + ' : ' + msg + "\n")