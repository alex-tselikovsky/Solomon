from sameChecker import Checker

texts = ["text1", "text2"]
checker  = Checker(texts)
results = checker.find_index_of_similar("text3",  min_sim=0.3)
print(results)