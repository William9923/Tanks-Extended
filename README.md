# IF3210 2021 Unity K03 15: Tanks II (EXtended)
---
## Deskripsi
Tanks II (EXtended) merupakan suatu game dimana pemain akan memainkan tanks dan melawan satu sama lain dengan menggunakan senjata dan troops yang ada. Pada game ini, pemain akan bermain dalam 3 ronde. Pemain yang memenangkan paling banyak ronde yang akan memenangkan permainan (battle royale). Pemain akan disenjatai dengan machine gun sebagai senjata default. Saat permainan, cash akan berjatuhan secara periodik dan pemain akan mendapatkan cash ketika badan Tank pemain bersentuhan dengan cash di field. Pemain dapat mengakses Shop untuk meng-upgrade senjata yang dimiliki tank menjadi shell yang dapat meledak dengan cash yang telah didapat, namun shell memiliki jumlah yang terbatas sehingga perlu digunakan di saat yang tepat. Selain itu, pemain juga dapat menyewa troops untuk 1 ronde menggunakan cash yang didapatkan. Troops yang tersedia dibagi menjadi 2, yaitu CashFinder untuk membantu mencari Cash bagi pemain, dan ShooterSoldier untuk membantu pemain menyerang musuh. Tidak hanya itu, pemain juga dapat mengganti preferensi nama pemain serta besar suara game pada lobby main menu (bagian Option).

Sebagai tambahan, map yang terdapat pada game ini dibagi menjadi 2, yaitu Dessert Map dan Snowy Map. Kedua map tersebut memberikan tantangan tersendiri bagi pemain. Tidak hanya itu, game ini juga disertai dengan game mode tambahan Countdown time money race, dimana pemain akan bersaing untuk mendapatkan cash paling banyak. Pemain yang mati juga akan langsung respawn (dengan timer tertentu), sehingga game mode ini lebih diarahkan untuk mode "have fun" bagi pemain - pemain Tanks II (EXtended)

## Cara Kerja (Fungsionalitas Game) & Screenshot
Berikut cara kerja dari beberapa fungsionalitas dalam game : 
| No | Spesifikasi | Penjelasan |
|----|-------------|------------|
| 1  | Multiplayer dapat dijalankan secara local area network dengan lebih dari dua pemain. Implementasi matchmaking (lobby) dibebaskan. | Multiplayer diimplementasikan dengan menggunakan client authority dengan library Mirror, namun belum terimplementasi dengan baik akibat kurangnya waktu sehingga game hanya menggunakan sistem multiplayer support 2 player dengan keyboard yang sama. Sampel multiplayer dapat dilihat pada Branch feature/networking.   |
| 2  | Pada main menu, terdapat settings untuk mengatur intensitas suara dan nama pemain yang diimplementasi dengan PlayerPrefs.            | Terdapat Main Meny yang bisa digunakan untuk mengatur nama pemain 1 dan pemain 2 serta pengaturan suara pada opsi Option sebelum memilih Map dan Game Mode.|
| 3  | Desain pada map harus berbeda dari desain semula pada tutorial namun dapat menggunakan aset apapun.            | Map baru yang ditambahkan terdapat 2, yaitu Map Dessert (menyerupai Map pada tutorial namun dengan perubahan asset serta layout) dan Map Snowy yang merubah material asset menjadi salju           |
| 4  | Terdapat objek cash yang muncul secara periodik. Tank dapat mengambil cash untuk menambahkan uang yang dimilikinya.            | Object Cash bermunculan secara periodik dengan jatuh secara ke map pada daerah random, direpresentasikan dengan coin berwarna abu - abu. Cash ini dibuat secara custom dan nantinya bisa digunakan untuk upgrade weapon dan untuk membeli shell pada game mode battle royale. Sementara itu, pada game mode Time Attack, Cash yang bermunculan secara periodik digunakan untuk point player.           |
| 5  | Terdapat minimal dua jenis senjata dengan karakteristik yang berbeda. Pemain dapat membeli senjata dengan menggunakan cash.            | Terdapat 2 jenis karakter, yaitu Cash Finder dan Shooter Troop. Cash Finder akan bergerak mencari cash untuk player (bergerak secara independen). Apabila tidak ada cash disekeliling rangenya lagi, ia akan bergerak mengikuti player kembali sebelum mendapatkan cash pada rangenya lagi. Sedangkan Shooter Troop akan bergerak mengikuti pemain, dan menembak setiap pemain lawan yang didalam range tembakan troop.           |
| 6  | Terdapat minimal dua jenis karakter bergerak yang dapat dikeluarkan (tempat dibebaskan) dengan membayar cash, memiliki behavior yang berbeda, dan dapat diserang dengan peluru. Sebagai referensi, karakter dapat berupa infantry yang berjalan mengikuti pergerakan musuh dan menembak secara periodik.            | Animasi pada CashFinder dan Shooter Troop menggunakan Animator Controller dengan 3 jenis animation clip, yaitu shooting (khusus pada Shooter Troop), moving dan idle.           |
| 7  | Animasi saat karakter bergerak melakukan aksi (contohnya jalan, tembak, dan diam) harus berbeda, namun dapat menggunakan aset apapun.            | Baik tank dan karakter (troop) memiliki komponen Collider untuk memungkinkan terjadinya collision.           |
| 8  | Terdapat interaksi collision antara objek bergerak seperti tank dan karakter.            | Terdapat credits pada main menu untuk menampilkan Assets yang digunakan oleh kelompok kami, dan ditampilkan saat pemain akan bermain game.           |
| 9  | Terdapat lebih dari satu map yang dapat dipilih oleh pemain.            | Pemain dapat memilih 2 jenis map yaitu Map Dessert dan Map Snow.           |
| 10 | Terdapat lebih dari satu game mode selain battle royale. Sebagai referensi, contoh game mode lain adalah racing atau timed money race.            | Terdapat 2 buah game yang dapat dipilih oleh pemain dalam match lobby (main menu). Game modes yang dapat dipilih adalah Battle Royale dan Time Attack dimana pemain beradu untuk mengumpulkan cash sebanyak - banyaknya dalam 60 detik.           |

## Screenshot Game
Berikut beberapa screenshot in-game saat bermain game mode :

### Main Menu / Lobby
![Main Menu](docs/mainmenu.jpg)
### Option
![Option Menu](docs/optionmenu.jpg)
### Map Snow
![Snow Map Start](docs/roundstart_snow.jpg)

### Map Dessert
![Map Dessert](docs/roundstart_desert.jpg)

### Shop
Tampilan Shop sebelum player mengupgrade weapon : 
![Shop Before Upgrade](docs/shop1.jpg)

Tampilan Shop setelah player mengupgrade weapon : 
![Shop After Upgrade](docs/shop2.jpg)

### Weapon
Senjata pertama dari tank, yaitu cannon yang menembakkan shell:
![Shell Shooter](docs/weapon1.jpg)

Senjata kedua dari tank, yaitu machine gun yang menembakkan peluru:
![Machine Gun](docs/weapon2.jpg)

### Game Mode
Tampilan saat player memilih mode game :
![Choose Game Mode](docs/gamemenu.jpg)

Tampilan game battle royale :
![Battle Royale](docs/roundstart_desert.jpg)

Tampilan game saat menang battle royale:
![Battle Royale 2](docs/battle-royale-win.jpg)

Tampilan game time attack :
![Time Attack](docs/roundstart_time_snow.jpg)

Tampilan game saat menang time attack : 
![Time Attack 2](docs/round_end_time_snow.jpg)

### Coin Finder
Non-Player Character yang berjalan di sekitar arena dan mengambil koin terdekat
![Shooter Troop](docs/coincollector.jpg)

### Shooter Troop
Non-Player Character yang menembak tank lawan yang ada di rangenya
![Shooter Troop](docs/shooter.jpg)

### Credit
![Credit](docs/credits.jpg)

### Lobby Multiplayer
Berikut merupakan tampilan lobby pada multiplayer dengan LAN (Local Area Network) :

* Lobby kosong
![LAN Lobby](docs/lobby.jpg)

* Lobby dengan 2 pemain yang tersambung dengan LAN:
![LAN Lobby 2](docs/lobby2.jpg)

## Library External

Berikut penggunaan library eksternal pada game :
- [Tanks!](https://assetstore.unity.com/packages/essentials/tutorial-projects/tanks-tutorial-46209) : Digunakan sebagai 
- [ToonyTinyPeople](https://assetstore.unity.com/packages/3d/characters/toony-tiny-soldiers-demo-180904) : Digunakan untuk membuat karakter troops / infrantry serta untuk membuat animasi (package memiliki animation clip) dalam pembuatan animator controller (dengan state diagram)
- [Tanks! Reference](https://assetstore.unity.com/packages/essentials/tutorial-projects/tanks-reference-project-80165) : Digunakan untuk mendapatkan asset - asset terkait, seperti pohon salju dan prefab lainnya untuk pembuatan level Art untuk map snow dan dessert.
- [Mirror](https://assetstore.unity.com/packages/tools/network/mirror-129321) : Digunakan untuk membuat multiplayer pada game (belum berhasil diimplementasikan namun sudah diimport dalam project) 

## Pembagian Kerja

* 13518138 - William

| No | Kontribusi |
|----|------------|
| 1  | Membuat map yang berbeda dari tutorial (map dessert dan snowy area) | 
| 2  | Membuat object cash yang muncul (berjatuhan) secara periodik | 
| 3  | Membuat senjata machine gun pada game (default weapon) |
| 4  | Membuat karakter dengan karakteristik (logic pathfinding) Shooter Troop | 
| 5  | Membuat logic colliding karakter dengan tank | 
| 6  | Membuat animator controller untuk karakter (troop) dalam game |
| 7  | Membuat map yang berbeda dari tutorial (map dessert dan snowy area) | 
| 8  | Membuat object cash yang muncul (berjatuhan) secara periodik | 
| 9  | Membuat senjata machine gun pada game (default weapon) |
| 10 | Membuat game mode time limit rush (persaingan siapa mendapat paling banyak cash dalam 60 detik) |
| 11 | Mencoba membuat multiplayer dengan Mirror (tidak berhasil seutuhnya) |

* 13518144 - Fabianus Harry Setiawan

| No | Kontribusi |
|----|------------|
| 1  | Membuat tampilan main menu |
| 2  | Membuat tampilan shop |
| 3  | Membuat logic shop dan upgrade weapon |
| 4  | Membuat karakter dengan karakteristik (logic pathfinding) Cash Finder |
| 5  | Membuat credits untuk asset yang dipakai dalam game |
| 6  | Melakukan Playtesting terhadap game secara menyeluruh |
| 7  | Mengimplementasikan efek pada weapon machine gun |
| 8  | Membuat dokumentasi |

* 13516060 - Gloryanson Ginting

Tidak ada



