import requests
import json
import pprint


def login(username, password, header):
    """logs into reddit, saves cookie"""
 
    print 'begin log in'
    #username and password
    UP = {'user': username, 'passwd': password, 'api_type': 'json',}
    #POST with user/pwd
    client = requests.session()
    client.headers.update(header)
    r = client.post('http://www.reddit.com/api/login', data=UP)
 
    #print r.text
    #print r.cookies
 
    #gets and saves the modhash
    print r.text
    j = json.loads(r.text)
 
    client.modhash = j['json']['data']['modhash']
    print '{USER}\'s modhash is: {mh}'.format(USER=username, mh=client.modhash)
    client.user = username
    def name():
 
        return '{}\'s client'.format(username)
 
    #pp2(j)
 
    return client


header={'user-agent' : 'qualitybot/2.0',}
chose = login('Quality_Posts', 'qw3rtyui0p', header)
r = chose.post('http://www.reddit.com/api/comment', data={'api_type': 'json', 'text' : '\>/r/DotA2\n\n\>Quality Content\n\nPick one.', 'thing_id' : 't3_2817zd', 'uh' : chose.modhash, })
print json.loads(r.text)
raw_input()

