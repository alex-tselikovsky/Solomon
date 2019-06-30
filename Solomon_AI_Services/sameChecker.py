from sklearn.feature_extraction.text import TfidfVectorizer
from sklearn.metrics.pairwise import linear_kernel 
import numpy as np
import  json

class Checker(object):
    
    def __init__(self, texts):
        self.texts = texts
        f = open('stopwords.txt','r', encoding='utf-8')
        stopwords_ru = f.read().splitlines()
        f.close()
        self.tf = TfidfVectorizer(analyzer='word', ngram_range=(1,3), min_df = 0, stop_words = stopwords_ru)
        self.tfidf_matrix =  self.tf.fit_transform(texts)
        

    def find_index_of_similar(self, text, top_n = 5, min_sim=0.8):
        cosine_similarities = linear_kernel(self.tf.transform([text]),  self.tfidf_matrix).flatten()
        related_docs_indices = [i for i in cosine_similarities.argsort()[::-1]]
        return [{index:related_index, similarity:cosine_similarities[related_index], text:self.text[related_index]} for related_index in related_docs_indices if cosine_similarities[related_index] >= min_sim and cosine_similarities[related_index] < 0.98 ][0:top_n]

