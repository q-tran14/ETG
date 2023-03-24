# Enter The Dungeon (clone from Enter The Gungeon)
## Các Folder được cung cấp:
- [x] Sprites
- [x] Sounds

## Phân công:
### Boss:

| Quân | Phát | Phúc | Duy | Thiện |
| ----------- | ----------- | ----------- | ----------- | ----------- |
| &#x2610; Final Lich | &#x2610; Old Bullet King | &#x2610; Boss Final Guide | &#x2610; Bullet King | &#x2610; Gatling Gull |
| &#x2610; Beholster | &#x2610; Dragun | &#x2610; Boss Final Marine | ---- | &#x2610; Meduzi |

### Enemy:
| Quân | Phát | Phúc | Duy | Thiện |
| ----------- | ----------- | ----------- | ----------- | ----------- |
|&#x2610; angry book blue | &#x2610; angry book | &#x2610; angry book green | &#x2610; angry book necro | &#x2610; big hell face |
|&#x2610; bullat	| &#x2610; bubble lizard	| &#x2610; bloodbulon | &#x2610; blobulin	| &#x2610; bird enemy |
|&#x2610; bullat ghost | &#x2610; bubble lizard red | &#x2610; bullet man shroomed | &#x2610; blobuloid | &#x2610; bullet man skeleton |
|&#x2610; bullat shotgun	| &#x2610; bullet rigle professional | &#x2610; bullet shark | &#x2610; blobulon | &#x2610; bullet man mutant |
|&#x2610; bullet man bandana	| &#x2610; bulllet man magic	| &#x2610; bullet man | &#x2610; bullet rifle man	 | &#x2610; bullet shotgun man mutant |
|&#x2610; bullet shotgun man sawed off |&#x2610; chance bullet | &#x2610; cubulon	| &#x2610; cultist bald | &#x2610; dynamite guy |
|&#x2610; ghost | &#x2610; giant bullat | &#x2610; grenade guy	| &#x2610; grim reaper | &#x2610; gripmaster |
|&#x2610; gun nut | &#x2610; gun nut chain | &#x2610; kaliber cultist bullet main	| &#x2610; key bullet kin | &#x2610; lead maiden|
|&#x2610; lead wizard blue | &#x2610; lead wizard	| &#x2610; metal cube guy | &#x2610; mimic blackbone | &#x2610; mimic pedestal |
|&#x2610; mimic rat chest | &#x2610; mimic red gold | &#x2610; mimic silver chest | &#x2610; mimic wood chest | &#x2610; mushroom guy small |
|&#x2610; mushroom guy big | &#x2610; phase spider | &#x2610; poisbulon | &#x2610; poopulon | &#x2610; powder skull |
|&#x2610; shotgun kin | &#x2610; sunburst blue | &#x2610; shotgun creecher | &#x2610; shelleton | &#x2610; rubber bullet |
|&#x2610; sunburst | &#x2610; T-Bulon	| &#x2610; wizard blue | &#x2610; wizard purple | &#x2610; wizard yellow |
|&#x2610; wizard red| ---- | ---- | ---- | ---- |

## Map được xử lí bởi:
* Ai làm scene nào thì vào edit file README.md trong ***branch của mình***. Thay "..." bằng ***tên của mình***. Khi hoàn thành thì xóa dấu cách trong ngoặc vuông [] và thay bằng chữ **x**.

VD:

    [ ] Start: ***...*** --> [x] Start: ***Quân***
    &#x2610; == [ ] --> &#x2611; == [x] 
 
- [x] Start: ***Quân***
- [x] The Breach: ***Quân***
- [x] Tutorial room: ***Phát***
- [x] Shopping room: ***Phát***
- [x] Chamber 1: ***Quân***
- [ ] Chamber 2: ***Thiện***
- [ ] Chamber 3: ***Duy***
- [x] Hidden Chamber 2: ***Phát***
- [x] FinalBoss_Lich: ***Quân***
- [x] Aimless Void: ***Quân***
- [x] Boss Chamber for Hunter: ***Phúc***
- [x] Boss Chamber for Marine: ***Phúc***

### Sorting Layer - Order in Layer
> - Group object name == Sorting Layer name:
>     - TileMap name - order in layer [n]

- Hole:
    - UnderSurface - 0
    - Surface - 1 (animated tiles)
- Floor:
    - Ground - 0
    - AnotherBrickOnGround - 1
- Shadow - 0
- StaticObjectFloor - 0
- Character_Object_Projectile - 0
- Wall:
    - BodyWall - 0
    - BorderWall - 1
    - FrontWall - 2 (static tiles / animated tiles)
- Roof - 0

## Vấn đề cần lưu ý:
- Trong Sprites - Main Characters, **Guide** chính là **Hunter**.
- Sprite của Shotgun Kin không có folder ảnh lẻ.
- Folder Bosses và Enemies trong folder Sounds không được phân đúng loại nên nếu kiếm sound của các Enemy và Boss thì nên kiểm ở cả 2 folder này.
- Một số Sprite ko có đúng tên so vs trong các link tham khảo nên cần xem hình để phân biệt.
- Các Sprite lẻ cắt ra từ Sprite - sheet của Shotgun Kin chưa được đặt tên xong ( chỉ vừa đặt được vài cái ).
- Sprite được dựng sẵn (thông thường là các map đặc biệt như Breach, Aimless Void, Boss room của nhân vật) - Pixels Per Unit (Trong Sprite Editor): ***24***
- Sprite của character, enemy tileset, env và platform - map spawn enemy thông thường - Pixels Per Unit (Trong Sprite Editor): ***16***
- Làm xong thì push lên branch của bản thân rồi vô github tạo ***pull request*** để mn cùng duyệt xong. ***TUYỆT ĐỐI KHÔNG ĐC PHÉP TỰ Ý MERGE VÔ BRANCH "MASTER".***

***Quy ước kích thước corridor: **[ Tìm hiểu chi tiết ở Chamber 1, Tutorial ở các tilemap liên quan đến wall ]** ***
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
