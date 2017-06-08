#utf-8
import cgi
import requests
from bs4 import BeautifulSoup
import bs4 #为了使用isinstance()函数

def getHTMLText(url):
    try:
        kv={'user-agent':'Mozilla/5.0'}
        r=requests.get(url,headers=kv,timeout=30) #timeout，超时时间，单位s （如果在timeout的时间内没有连接则抛出异常）
        r.raise_for_status() #如果状态代码不是200，引发HTTPError异常
        r.encoding=r.apparent_encoding #根据实际情况，设定读取编码的方式
        return r.text
    except:
        return ""

def fillUnivList(ulist,html,flag):
    soup=BeautifulSoup(html,"html.parser") #bs4库中BeautifulSoup类的 html解析器
    #print('soup_finished')
    for tr in soup.find_all('a',"cse-search-result_content_item_top_a"): #观察网页，遍历指定的'a'标签
        content_href=tr['href'] 
        #temp=tr.strip().replace('<b>','')
        #temp=temp.strip().replace('</b>','')
        #content_name=temp
        content_name='the link of resource: '
        #print(content_name)
        #print(content_href)
        ulist.append([content_name,content_href]) # 此处在列表ulist中添加子列表(append()）
    #for i in range(10):
        #u=ulist[i]
        #print(u[0],u[1])

def printUnivList(ulist,num):
    #print("hi/n")
    tplt="{0:<10}\t{1:<10}" # ^ < > 分别为 居中
    #tplt="{0:<10}\t{1:<10}\t{2:<10}" # ^ < > 分别为 居中 左对齐 右对齐 
    print("人气最高的资源链接，依照点击数排名如下：") #最后的chr(12288)是指设定的填充字符，在tplt中{3}即这个
    #print("{:^10}\t{:^6}\t{:^10}".format("排名","学校","总分"))
    for i in range(num): #range(num)  等价于range（0,num），即[0,1,2,3,4]
        u=ulist[i]
        print(u[0],u[1])
        #print("{:^10}\t{:^6}\t{:^10}".format(u[0],u[1],u[2]))
#<a href="http://www.baidu.com/?noreferer" rel="noreferrer target="_blank">
def printHtml(ulist,num):    
    for i in range(num):
        u=ulist[i]
        print("the link of resource:        ") 
        this=str('''<a href="''')+u[1]+judge_front+judge_tail_1+judge_tail_2+str('''">''')+u[1]+str('''</a>''')
        judge_front=str('''/?noreferer"''')
        judeg_tail_1=str(''' rel="noreferrer''')
        judge_tail_2=str('''" target=)print('''"_blank''')
	#print('''<a href="''')
	#print(u[1])
	#print('''">''')
	#print(u[1])
	#print('''</a>''')
        print(this)
	print("<br>")
        
def yunpan(key):
    flag=1;
    uinfo=[]
    url='http://www.wangpansou.cn/s.php?q='+key
    html=getHTMLText(url)
    fillUnivList(uinfo,html,flag)
    #print("hello,here")
    #printUnivList(uinfo,10) # 10 univs
    printHtml(uinfo,10)


print('Status:200 OK')
print('Content-Type:text/html')
print('')
print('''
<html>
    <head>
        <title>Share your world</title>
    </head>
    <body>  
	<h2>Search online : crawling web pages</h2>
        <h4>The most popular resource link is ranked below by clicking:</h4>
''')
form=cgi.FieldStorage()
key=unicode(form["name"].value,'GBK')
#print(key)
print("")
yunpan(key)
print('''
    </body>
</html>
''')

