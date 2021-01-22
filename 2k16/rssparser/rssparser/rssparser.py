import urllib2
from BeautifulSoup import BeautifulSoup
response = urllib2.urlopen('https://www.facebook.com/feeds/page.php?id=305291009614592&format=rss20')
html = BeautifulSoup(response.read(), convertEntities=BeautifulSoup.HTML_ENTITIES)
print html