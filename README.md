# The-net-of-Yu

Unity Editor Version: 2022.3.21f1

AlibabaPuHuiTi-3-65-Medium SDF.asset：https://drive.google.com/file/d/1Y3Wu5QaMdUJYI9B7_yZzbpQl-KEGTPAX/view?usp=sharing

图鉴Asset：https://assetstore.unity.com/packages/tools/animation/book-page-curl-55588?aid=1101ldiAE&utm_campaign=unity_affiliate&utm_medium=affiliate&utm_source=partnerize-linkmaker

2024/4/7 Update：
- 已把同类文件整理到相同文件夹中。
- 全部脚本的编码改成了utf-8，中文注释不会再显示乱码。
- 对话的字体全改为了AlibabaPuHuiTi-3-65-Medium，也已prefab化，目前可以正常显示中文，该字体商用。
- 实现水下跟随角色移动的spot light，按方向键上下左右移动，且可以调整重力。
- 背包系统实现90%，设置四个背包，分别装渔获，道具，资源和垃圾，急需可用的美术素材。
- 出海捕鱼scene的名字改为了fishing，增加了按左上角按键后退回主菜单的功能，增加了正上方显示倒计时的功能，增加了倒计时结束后显示获得物品的结算画面。
- 在CurrentSceneInventoryManager.cs脚本中，用Dictionary的方法保存获得的物体。利用AddItem()函数即可增加物品数量，在CountdownTimer.cs脚本中倒计时结束后运行CurrentSceneInventoryManager.cs脚本中的PrintInventory()函数把获得的物品显示在结算画面上。
