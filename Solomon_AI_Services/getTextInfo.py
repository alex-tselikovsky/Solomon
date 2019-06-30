from ipymarkup import AsciiMarkup, Span, BoxMarkup
import re

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
addressExtractor = AddressExtractor()



class TextInfo(object):
    def __init__(self, clear_text, addresses):
        self.clear_text = clear_text
        self.addresses


def getInfo(text):
    address_matches = addressExtractor(text)
    spans = []
    facts = []
    for extractor in extractors:
        matches = extractor(text)
        spans.extend(_.span for _ in matches)
        facts.extend(_.fact.as_json for _ in matches)

        #for index, match in enumerate(matches):
        #    print(index, repr(match.fact.normalized))

    for span in spans:
        print(text[span.start:span.stop])


    result=text

    spans2 = [(start, stop, stop-start) for start, stop in spans]

    spans2.sort(key=lambda x:x[2], reverse=True)
    for (start,stop,l) in spans2:
        print(text[start:stop])
        result=result.replace(text[start:stop],"",1)
    print(result)
    return TextInfo(result, matches)
    #markup = BoxMarkup(text, spans)


#show_markup(text, spans)
#show_json(facts)

#text = '''
#Взыскать к индивидуального предпринимателя Иванова Костантипа Петровича дата рождения 10 января 1970 года, проживающего по адресу город Санкт-Петербург, ул. Крузенштерна, дом 5/1А 8 000 (восемь тысяч) рублей 00 копеей госпошлины в пользу бюджета РФ ООО Рога и копыта
#'''
#getInfo(text)