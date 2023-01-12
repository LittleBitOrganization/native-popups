# Native Popups

Модуль предназначен для отображения нативных попапов для <b>iOS, Android и Unity Editor</b>.

# Quick Start

Нативные попапы имеют заголовок, описание и  максимум 3 кнопки : позитивная, нейтральная и негативная.

1. Для начала необходимо создать фабрику <b> NativePopupFactory</b>.
2. Создать <b>NativePopup</b> с помощью <b>NativePopupFactory.Create()</b>.
3. С помощью методов <b>SetContent()</b> и <b>SetTitle()</b> задать названия заголовка и описания.
4. С помощью методов <b>AddPositiveButton(), AddNeutralButton() и AddNegativeButton()</b> создать кнопки у попапа.
5. В методы создания кнопок необходимо передать название кнопки и метод который вызовется при нажатии на кнопку.

### Пример:

```c#
showThreeButton.onClick.AddListener(() =>
            {
                NativePopupFactory nativePopupFactory = new NativePopupFactory();
                nativePopupFactory.Create()
                    .SetContent("Description")
                    .SetTitle("New Title")
                    .AddPositiveButton("Ok", () =>
                    {
                        Debug.LogError("Click Ok in Controller");
                        result.text = "Result : Positive";
                    })
                    .AddNegativeButton("Not Now", () =>
                    {
                        Debug.LogError("Click Now Now in Controller");
                        result.text = "Result : Negative";
                    })
                    .AddNeutralButton("Neutral", () =>
                    {
                        Debug.LogError("Neutral");
                        result.text = "Result : Neutral";
                    })
                    .Show();

            });
```

Пример работы нативных попапов можно посмотреть на сцене <b>Show_Alerts</b> и в классе <b>PopupController</b>.