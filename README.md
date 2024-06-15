<p float="left">
  <img src="https://github.com/yusufKemalPinarci/EnUcuzUrunBul/blob/master/proje%20resimleri/alt%20kategori.png" width="400" height="200" />
  <img src="https://github.com/yusufKemalPinarci/EnUcuzUrunBul/blob/master/proje%20resimleri/ana%20kategori.png" width="400" height="200" />
  <img src="https://github.com/yusufKemalPinarci/EnUcuzUrunBul/blob/master/proje%20resimleri/arad%C4%B1%C4%9F%C4%B1m%C4%B1z%20%C3%BCr%C3%BCn%20bulma.png" width="400" height="200" />
  <img src="https://github.com/yusufKemalPinarci/EnUcuzUrunBul/blob/master/proje%20resimleri/giris.png" width="400" height="200" />
</p>
<p float="left">
  <img src="https://github.com/yusufKemalPinarci/EnUcuzUrunBul/blob/master/proje%20resimleri/guncelleme%20listeleme.png" width="200" height="400" />
  <img src="https://github.com/yusufKemalPinarci/arkadasekle/blob/master/bitirme_projesi_ss'leri/Screenshot_20240602_010522.png" width="200" height="400" />
  <img src="https://github.com/yusufKemalPinarci/arkadasekle/blob/master/bitirme_projesi_ss'leri/Screenshot_20240602_010658.png" width="200" height="400" />
</p>

import os

# Resimlerin bulunduğu klasör
image_folder = 'https://github.com/yusufKemalPinarci/EnUcuzUrunBul/tree/master/proje%20resimleri'

# README dosyasına yazmak için dosya aç
with open('README.md', 'a') as readme_file:
    # Klasördeki dosyaları listele
    for image_filename in os.listdir(image_folder):
        if image_filename.endswith(('.png', '.jpg', '.jpeg', '.gif')):
            # Markdown formatında resim ekle
            readme_file.write(f'![{image_filename}]({image_folder}/{image_filename})\n')



