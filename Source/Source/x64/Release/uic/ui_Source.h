/********************************************************************************
** Form generated from reading UI file 'Source.ui'
**
** Created by: Qt User Interface Compiler version 5.15.0
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_SOURCE_H
#define UI_SOURCE_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QLabel>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QProgressBar>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_SourceClass
{
public:
    QWidget *centralWidget;
    QProgressBar *homeProgressBar;
    QLabel *label;
    QLabel *label_2;
    QStatusBar *statusBar;

    void setupUi(QMainWindow *SourceClass)
    {
        if (SourceClass->objectName().isEmpty())
            SourceClass->setObjectName(QString::fromUtf8("SourceClass"));
        SourceClass->resize(1134, 604);
        SourceClass->setStyleSheet(QString::fromUtf8("background-color: rgb(255, 252, 247);"));
        centralWidget = new QWidget(SourceClass);
        centralWidget->setObjectName(QString::fromUtf8("centralWidget"));
        homeProgressBar = new QProgressBar(centralWidget);
        homeProgressBar->setObjectName(QString::fromUtf8("homeProgressBar"));
        homeProgressBar->setGeometry(QRect(220, 350, 691, 23));
        homeProgressBar->setValue(24);
        label = new QLabel(centralWidget);
        label->setObjectName(QString::fromUtf8("label"));
        label->setGeometry(QRect(330, 140, 501, 181));
        label->setStyleSheet(QString::fromUtf8("font: 48pt \"Ravie\";"));
        label_2 = new QLabel(centralWidget);
        label_2->setObjectName(QString::fromUtf8("label_2"));
        label_2->setGeometry(QRect(290, 380, 261, 16));
        SourceClass->setCentralWidget(centralWidget);
        statusBar = new QStatusBar(SourceClass);
        statusBar->setObjectName(QString::fromUtf8("statusBar"));
        SourceClass->setStatusBar(statusBar);

        retranslateUi(SourceClass);

        QMetaObject::connectSlotsByName(SourceClass);
    } // setupUi

    void retranslateUi(QMainWindow *SourceClass)
    {
        SourceClass->setWindowTitle(QCoreApplication::translate("SourceClass", "Source", nullptr));
        label->setText(QCoreApplication::translate("SourceClass", "Hangman", nullptr));
        label_2->setText(QCoreApplication::translate("SourceClass", "Please wait for the game to begin . . .", nullptr));
    } // retranslateUi

};

namespace Ui {
    class SourceClass: public Ui_SourceClass {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_SOURCE_H
