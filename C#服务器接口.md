#### 加密API：

1. GET：

   字段：method（加密方法，小写）、str（加密对象）、key（密钥）

   例：http://www.mortyw.cn/cipherbreaker/api/encrypt?method=caesar&str=abc&key=2

   注：修改“=”后面的值即可

2. POST：

   字段：同上

   例：http://www.mortyw.cn/cipherbreaker/api/encrypt

   注：在POST体中以键值对方式填入字段

#### 解密API：

1. GET

   字段：method（解密方法，小写）、str（解密对象）、key（密钥）

   例：http://www.mortyw.cn/cipherbreaker/api/decrypt?method=caesar&str=cde&key=2

2. POST：

   字段：同上

   例：http://www.mortyw.cn/cipherbreaker/api/decrypt

#### 破解API：

1. GET

   字段：method（破解方法，小写）、str（破解对象）

   例：http://www.mortyw.cn/cipherbreaker/api/break?method=caesar&str=cde

2. POST：

   字段：同上

   例：http://www.mortyw.cn/cipherbreaker/api/break

#### 获取历史数据：

1. EncryptItem
2. DecryptItem
3. BreakItem