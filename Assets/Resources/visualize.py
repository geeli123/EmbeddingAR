from sklearn.manifold import MDS
import numpy as np
import json
import pyemblib
import random

embedding_file = "top_10000_emb.txt"

include = set(['red', 'black', 'green', 'orange', 'apple', 'king', 'queen', 'man', 'woman', 'moscow', 'russia', 'tokyo', 'japan'])

embeddings = pyemblib.read(embedding_file, mode=pyemblib.Mode.Text)
keys = list(embeddings.keys())
values = list(embeddings.values())

new_vals, new_keys = [], []

for i in range(len(keys)):
  if keys[i] in include or random.random() < 0.05: 
    new_keys.append(keys[i])
    new_vals.append(values[i])

values = np.array(new_vals)
keys = new_keys

mds = MDS(n_components=3)
realspace = mds.fit_transform(values)

f = open('3dembeddings.csv', 'w')
for i in range(len(keys)):
  f.write(keys[i] + ',' + str(realspace[i][0]) + ',' + str(realspace[i][1]) + ',' + str(realspace[i][2]) + '\n')
f.close()
