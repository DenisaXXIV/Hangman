#pragma once

#include <QtWidgets/QMainWindow>
#include "ui_Source.h"

class Source : public QMainWindow
{
    Q_OBJECT

public:
    Source(QWidget *parent = Q_NULLPTR);

private:
    Ui::SourceClass ui;
};
