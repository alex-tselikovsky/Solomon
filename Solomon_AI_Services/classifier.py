
from __future__ import print_function

import logging
import numpy as np
from optparse import OptionParser
import sys
from time import time
import matplotlib.pyplot as plt

from sklearn.datasets import fetch_20newsgroups
from sklearn.feature_extraction.text import TfidfVectorizer
from sklearn.feature_extraction.text import HashingVectorizer
from sklearn.feature_selection import SelectFromModel
from sklearn.feature_selection import SelectKBest, chi2
from sklearn.linear_model import RidgeClassifier
from sklearn.pipeline import Pipeline
from sklearn.svm import LinearSVC
from sklearn.linear_model import SGDClassifier
from sklearn.linear_model import Perceptron
from sklearn.linear_model import PassiveAggressiveClassifier
from sklearn.naive_bayes import BernoulliNB, ComplementNB, MultinomialNB
from sklearn.neighbors import KNeighborsClassifier
from sklearn.neighbors import NearestCentroid
from sklearn.ensemble import RandomForestClassifier
from sklearn.utils.extmath import density
from sklearn import metrics

from ipymarkup import AsciiMarkup, Span, BoxMarkup
import re
from getTextInfo import getInfo

f = open('stopwords.txt','r', encoding='utf-8')
stopwords_ru = f.read().splitlines()
f.close()


class Treatment (object):
    def __init__(self, text, category, category_index):
        self.text = text
        self.category = category
        self.category_index = category_index 

class Classifier(object):

     def __init__(self):
         pass 
     
     def fit(self):
        # Display progress logs on stdout
        logging.basicConfig(level=logging.INFO,
                            format='%(asctime)s %(levelname)s %(message)s')

        # parse commandline arguments
        op = OptionParser()

        # work-around for Jupyter notebook and IPython console
       
        file = open('NashDomRyazan.json', 'r', encoding='utf-8')
        import  json
        import random
        data = json.loads(file.read())

        categories_list = [item.get("category","") for item in data]
        self.categories = list(set(categories_list))
        categories_curent = ['Городская территория', 'Дворовая территория', 'Дороги','Многоквартирные дома']

        lemmatized_texts = open("lemmatized_ryazan.txt",'r', encoding='utf-8').read().strip('\n*****\n').split('\n*****\n')


        #text_with_cats = [[lemmatized_texts[i], categories_list[i]] for i in range(len(lemmatized_texts)) if categories_list[i] in categories_curent]
        text_with_cats = [Treatment(lemmatized_texts[i], categories_list[i],i) for i in range(len(lemmatized_texts)) if categories_list[i] in categories_curent]

        random.shuffle(text_with_cats)

        train = text_with_cats

        data_train_data = [item.text for item in train]

        data_train_target = [self.categories.index(item.category) for item in train]

        print('data loaded')

        # order of labels in `target_names` can be different from `categories`
        target_names = categories_curent


        def size_mb(docs):
            return sum(len(s.encode('utf-8')) for s in docs) / 1e6

        print("%d categories" % len(target_names))
        print()

        # split a training set and a test set
        y_train = data_train_target

        print("Extracting features from the training data using a sparse vectorizer")
        t0 = time()
        self.vectorizer = TfidfVectorizer(sublinear_tf=True, max_df=0.5, stop_words = stopwords_ru)

        X_train = self.vectorizer.fit_transform(data_train_data)
        
        #X_test = self.vectorizer.transform(data_test_data)

        # mapping from integer feature name to original token string
        feature_names = self.vectorizer.get_feature_names()

        if feature_names:
            feature_names = np.asarray(feature_names)


        def trim(s):
            """Trim string to fit on terminal (assuming 80-column display)"""
            return s if len(s) <= 80 else s[:150] + "..."
        self.clf = RandomForestClassifier(n_estimators=100)
        print('_' * 80)
        print("Training: ")
        print(self.clf)
        self.clf.fit(X_train, y_train)
        return self.clf
    
     def predict(self, text):
        text_vector = self.vectorizer.transform([text])
        category_index = self.clf.predict(text_vector)[0]
        return self.categories[category_index], category_index
