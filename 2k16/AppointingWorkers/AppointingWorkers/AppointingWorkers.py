
assignments = int(raw_input())
jobs = []
for i in range(assignments):
    jobs.append(raw_input())


positions = {}
for i in range(assignments):
    input = raw_input()
    name, occupations = input.split(' ')
    occupations = occupations.split(',')
    positions[name] = occupations




