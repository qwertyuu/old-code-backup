functions = {'>' : 'ptr+=1;',
             '<' : 'ptr-=1;',
             '+' : '_t[ptr]+=1;',
             '-' : '_t[ptr]-=1;',
             '[' : 'while(_t[ptr] > 0){',
             ']' : '}',
             '.' : 'Console.Write((char)_t[ptr]);',
             ',' : '_t[ptr] = (int)Console.ReadLine()[0]'
             }
def optimize(code):
    lines = code.split('\n')
    index = 0
    while(index < len(lines) - 1):
        
        ligne1 = lines[index]
        egal1 = ligne1.find('=')
        ligne2 = lines[index + 1]
        egal2 = ligne2.find('=')
        if(egal1 != -1 and egal2 != -1):
            if(ligne1[:egal1] == ligne2[:egal2]):
                lines[index] = ligne1[:egal1 + 1] + str(int(ligne1[egal1 + 1:-1]) + 1) + ';'
                del lines[index + 1]
                index -= 1
        index += 1
    return '\n'.join(lines)



def ToPyth(code):
    code = code.replace('\n', '')
    pythonCode = "using System;\nnamespace PYTHON{\nclass Program{\nstatic void Main(string[] args){\nint ptr=0;\nint[] _t = new int[1000];\n"
    for inst in code:
        pythonCode += functions[inst] + '\n'
    pythonCode += "}\n}\n}"
    pythonCode = optimize(pythonCode)
    f = open('C:\\temp\\lolCS.txt', 'w')
    f.write(pythonCode)
    f.close()
    print pythonCode

ToPyth("++++++++++[>+++++++>++++++++++>+++>+<<<<-]>++.>+.+++++++..+++.>++.<<+++++++++++++++.>.+++.------.--------.>+.>.")
raw_input()