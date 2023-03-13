# Enter The Dungeon (clone from Enter The Gungeon)
## Các Folder được cung cấp:
- [x] Sprites
- [x] Sounds

## Phân công:
### Boss:

| Quân | Phát | Phúc | Duy | Thiện |
| ----------- | ----------- | ----------- | ----------- | ----------- |
| Final Lich | Old Bullet King	| Boss Final Guide | Bullet King | Beholster |
| Gatling Gull | Dragun | Boss Final Marine | Blobulord | Meduzi |

### Enemy:
| Quân | Phát | Phúc | Duy | Thiện |
| ----------- | ----------- | ----------- | ----------- | ----------- |
| angry book blue |angry book | angry book green | angry book necro | big hell face |
|bullat	| bubble lizard	| bloodbulon | blobulin	| bird enemy |
|bullat ghost | bubble lizard red | bullet man shroomed | blobuloid | bullet man skeleton |
|bullat shotgun	| bullet rigle professional | bullet shark | blobulon | bullet man mutant |
|bullet man bandana	| bulllet man magic	| bullet man | bullet rifle man	 | bullet shotgun man mutant |
|bullet shotgun man sawed off |chance bullet | cubulon	| cultist bald | dynamite guy |
|ghost | giant bullat | grenade guy	| grim reaper | gripmaster |
|gun nut | gun nut chain | kaliber cultist bullet main	| key bullet kin | lead maiden|
|lead wizard blue | lead wizard	| metal cube guy | mimic blackbone | mimic pedestal |
|mimic rat chest | mimic red gold | mimic silver chest | mimic wood chest | mushroom guy small |
|mushroom guy big | phase spider | poisbulon | poopulon | powder skull |
|shotgun kin | sunburst blue | shotgun creecher | shelleton | rubber bullet |
|sunburst | T-Bulon	| wizard blue | wizard purple | wizard yellow |
|wizard red| ---- | ---- | ---- | ---- |

## Map được xử lí bởi:
* Ai làm scene nào thì vào edit file README.md trong ***branch của mình***. Thay "..." bằng ***tên của mình***. Khi hoàn thành thì xóa dấu cách trong ngoặc vuông [] và thay bằng chữ **x**.

VD:

    [ ] Start: ***...*** --> [x] Start: ***Quân***
 
- [ ] Start: ***Quân***
- [ ] The Breach: ***Quân***
- [ ] Tutorial room: ***Phát***
- [ ] Shopping room: ***Phát***
- [ ] Chamber 1: ***Quân***
- [ ] Chamber 2: ***Thiện***
- [ ] Chamber 3: ***Duy***
- [ ] Hidden Chamber 1: ***Duy***
- [ ] Hidden Chamber 2: ***Phát***
- [ ] FinalBoss_Lich: ***Thiện***
- [ ] Aimless Void: ***Quân***
- [ ] Boss Chamber for Hunter: ***Phúc***
- [ ] Boss Chamber for Marine: ***Phúc***

### Sorting Layer - Order in Layer
> - Group object name:
>     - TileMap name & Sorting Layer name - order in layer [n]

- Abyss_WaterHole_LavaHole_SpikeHole:
    - Under Surface - 0
    - Surface - 1 (animated tiles)
- Floor:
    - Ground - 0
    - Another Brick on Ground - 1
- Shadow - 0
- Static Object on Floor - 0
- Character_Object_Projectile - 0
- Wall:
    - Body Wall - 0
    - Border Wall - 1
    - Front of Wall - 2 (static tiles / animated tiles)

## Vấn đề cần lưu ý:
- Trong Sprites - Main Characters, **Guide** chính là **Hunter**.
- Sprite của Shotgun Kin không có folder ảnh lẻ.
- Folder Bosses và Enemies trong folder Sounds không được phân đúng loại nên nếu kiếm sound của các Enemy và Boss thì nên kiểm ở cả 2 folder này.
- Một số Sprite ko có đúng tên so vs trong các link tham khảo nên cần xem hình để phân biệt.
- Các Sprite lẻ cắt ra từ Sprite - sheet của Shotgun Kin chưa được đặt tên xong ( chỉ vừa đặt được vài cái ).
- Sprite được dựng sẵn (thông thường là các map đặc biệt như Breach, Aimless Void, Boss room của nhân vật) - Pixels Per Unit (Trong Sprite Editor): ***24***
- Sprite của tileset, env và platform - map spawn enemy thông thường - Pixels Per Unit (Trong Sprite Editor): ***16***
- Làm xong thì push lên branch của bản thân rồi vô github tạo ***pull request*** để mn cùng duyệt xong. ***TUYỆT ĐỐI KHÔNG ĐC PHÉP TỰ Ý MERGE VÔ BRANCH "MASTER".***

***Quy ước kích thước corridor:**[Tìm hiểu chi tiết ở Chamber 1, Tutorial ở các tilemap liên quan đến wall]
- Horizontal corridor:
  
![Imgur](https://imgur.com/vVfMSDg.png)
  
- Floor under wall:
  
![Imgur](https://imgur.com/4OfBeNd.png) 

- Vertical corridor:

![Imgur](https://imgur.com/bYpKH1U.png)

***Qui trình xử lý project:**
- Github Desktop: Fetch origin để load bài -> đảm bảo phải commit/push bài mới nhất của mình -> Fetch origin để load bài -> Update from master để pull và merge từ branch gốc
- CMD: 
## Hệ thống màn chơi và các scene:
![Imgur](https://i.imgur.com/de2ponc.png)

## Lưu ý trước khi bắt tay vô làm
1. [Sơ đồ từng Chamber](https://drive.google.com/file/d/1NMAKiJlCoooQzqXneosSSOAuTvSE_SlM/view) (1 - 5): có thể sử dụng lại (ngoại trừ các room đặc biệt).
2. ***Tạo nhánh mới có name là MSSV_HoTen.***

3. Khi ghép Sprite để làm Animation, có thể dùng Sprite Editor để cắt Sprite - Sheet được cung cấp thành cái Sprite nhỏ hơn ( Khuyến khích xài Sprite lẻ được cung cấp trong folder cùng tên để tạo Animation vì có thể sẽ có vài Sprite - Sheet cắt bị lỗi ).

4. Tab **Hierarchy** Các object phải được phân rõ loại để tiện tìm kiếm và chỉnh sửa:

![Imgur](https://imgur.com/YLScKYR.png)

5. Các website để tham khảo các Chamber:
- [The Breach](https://enterthegungeon.fandom.com/wiki/The_Breach?so=search)
- Tutorial Chamber: [Halls of Knowledge](https://enterthegungeon.fandom.com/wiki/Halls_of_Knowledge)
- Chambers:
  - Chamber 1: [Keep of the Lead Lord](https://enterthegungeon.fandom.com/wiki/Keep_of_the_Lead_Lord)
  - Chamber 2: [Black Powder Mine](https://enterthegungeon.fandom.com/wiki/Black_Powder_Mine)
  - Chamber 3: [Forge](https://enterthegungeon.fandom.com/wiki/Forge)
- Hidden Chambers:
  - Hidden Chamber 1: [Oubliette](https://enterthegungeon.fandom.com/wiki/Oubliette)
  - Hidden Chamber 2: [Abbey of the True Gun](https://enterthegungeon.fandom.com/wiki/Abbey_of_the_True_Gun)
- Final Boss: [Bullet Hell](https://enterthegungeon.fandom.com/wiki/Bullet_Hell)

Ngoài ra cũng cần tham khảo thêm trên Youtube để tạo hình các room cho mỗi chamber và các scene khác như:

- Start Scene
- The Breach
- Aimless Void
- 2 boss chamber trong cốt chuyện của Hunter và Marine

## Các lỗi thường gặp:
1. Lỗi khi có sự conflict khi update từ master về branch làm việc của mình trên Github Desktop

![mergeIssue](https://user-images.githubusercontent.com/30680192/224209180-c6da9537-50a2-4757-9565-52b419f780b3.png)
  Cách fix:
  - Xổ các lựa chọn ở nút mũi tên và Chọn modified đúng branch tên của mình 
  
  ![UIStep1](https://user-images.githubusercontent.com/30680192/224210068-8dd3aa7d-6013-49e0-9891-49423ac167f3.png)
  - Lúc này sẽ báo hết lỗi và có thể tiếp tục merge

![UIStep2](https://user-images.githubusercontent.com/30680192/224210381-dff738b2-5210-4899-a00b-eac920e7aa94.png)

Giải thích: Lỗi này xảy ra khi người chơi thực hiện chỉnh sửa file khác với branch chính (thêm/bớt sprite trong palette,...) nên khi update từ branch chính về sẽ bị xung đột do khác cấu trúc, nên ta phải thực hiện thêm phần chỉnh sửa của mình để override data của branch master chưa chỉnh sửa.
