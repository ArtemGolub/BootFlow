# BootFlow

Unity 6 проект с реализацией **Boot Flow** (Вариант A): Splash → Loading → Menu → Restart.

Стек: **VContainer**, **UniTask**, **R3**, **MVVM-подобный UI**.

## Требования

- Unity **6000.3.17f1** (Unity 6)

## Быстрый старт

1. Открой проект в Unity Hub.
2. Дождись импорта пакетов (VContainer, R3).
3. Открой сцену `Assets/Scenes/SampleScene.unity`.
4. Убедись, что на сцене есть:
   - GameObject с **`GameLifetimeScope`**
   - **`Canvas`** как дочерний объект `LifetimeScope` (для `RegisterComponentInHierarchy`)
   - Окна: `SplashWindow`, `LoadingWindow`, `MenuWindow` с соответствующими скриптами
5. Нажми **Play** — старт с `SplashState`.

