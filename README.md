# ILRuntime_Mono_Cecil

#### 介绍
从ILRuntime中迁出mono.cecil进行修改，减少imageReader中ReadBytes的GC。

ModuleDefinition.ReadModule(Stream stream)，使用内部的MonoMemoryStream。

MonoMemoryStream仅适用于运行时读取dll，pdb未测试，不适用于写入处理！