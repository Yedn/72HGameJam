# 72HGameJam

球类对战小游戏

基本玩法描述：
场地划分为红蓝两方，场地中央有一个“球”，每个玩家单个回合内可以操控一个“球员”的弹射，“球员”经过“球”时可以持有球，”球员“一旦在运动过程中碰撞到其他”球员“，则与被碰撞的”球员“交换球权。”球“一旦进入一方的网中则另一方得分。额定回合数后游戏结束，得分最高者获胜。

操作方法描述：
一：鼠标操作
1）点击选择球员——》2）长按选择蓄力——》3）拖动选择方向
二：键盘操作
1）数字键选择球员——》2）长按shift/space选择蓄力——》3）A/D（左移动键/右移动键）选择方向（逆时针/顺时针旋转）

UI流程描述：
开始界面——》入场特效——》比赛场地——》得分动画——》胜利动画——》返回开始界面

游戏物体性质基本描述：
球员：圆形外观，圆形碰撞箱
场地：矩形，边界判定
球网：矩形，带球属性球员入网判定
球：较小圆形，可附着在球员上，为球员添加”带球“属性

666