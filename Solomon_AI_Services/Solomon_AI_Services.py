from ipymarkup import AsciiMarkup, Span, BoxMarkup
import re
import json

from flask import Flask
from flask import request

from natasha import (
    NamesExtractor,
    AddressExtractor,
    DatesExtractor,
    MoneyExtractor,
    OrganisationExtractor,
    LocationExtractor
)
from natasha.markup import show_markup, show_json

extractors = [
    NamesExtractor(),
    AddressExtractor(),
    DatesExtractor(),
    MoneyExtractor(),
    OrganisationExtractor(),
    LocationExtractor()    
]




app = Flask(__name__)

@app.route('/getFacts', methods=['POST'])
def getFacts():
    print(request.is_json)
    content = request.get_json()
    text = content['text']

    facts = {}
    for extractor in extractors:
        matches = extractor(text)
        spans=[]
        spans.extend({"span":_.span, "text":text[_.span.start:_.span.stop]} for _ in matches)
        facts[type(extractor).__name__]=spans

    return  json.dumps(facts)

@app.route('/getSpans', methods=['POST'])
def getSpans():
    print(request.is_json)
    content = request.get_json()
    
    print(content['text'])

    text = content['text']
    spans = []
    facts = []
    for extractor in extractors:
        matches = extractor(text)
        spans.extend(_.span for _ in matches)


    for span in spans:
        print(text[span.start:span.stop])

    return  json.dumps({"spans":spans, "facts":facts})


from sameChecker import Checker
checker = Checker()

@app.route('/updateAnswers',methods=['POST'])
def updateAnswers():
    text_list = request.get_json()
    checker.init(text_list)
    return "ok"

@app.route('/getClosestAnswer', methods=['POST'])
def getClosest():
    text =  request.get_json()["text"]
    result =checker.find_index_of_similar(text)
    return  json.dumps(result)



@app.route('/')
def index():
    return "Hello, World!"

if __name__ == '__main__':
    app.run(debug=True)





#app = Flask(__name__)
#@app.route('/')

#@app.route('/postjson', methods=['POST'])
#def post():
#    print(request.is_json)
#    content = request.get_json()
#    print(content)
#    print(content['id'])
#    print(content['name'])

#    return 'JSON posted'

#def index():
#    return "Hello, World!"
#if __name__ == '__main__':
#    app.run(debug=True)
