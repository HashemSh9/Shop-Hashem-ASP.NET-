function regS() {
    Swal.fire({
        title: "نجاح !",
        text: "تم إنشاء الحساب بنجاح!",
        icon: "success",
        button: 'تسجيل دخول'


    }).then(() => {
        window.location.href = "/ActEmail.aspx";
    });
}
    function DoneContent() {
        Swal.fire({
            title: "نجاح !",
            text: "تم إستلام رسالتك بنجاح!",
            icon: "success",
            button: 'حسنا'


        }).then(() => {
            
        });

}
function CheckStutUser() {
    Swal.fire({
        title: "فشل !",
        text: "تم إيقاف حسابك لغرض التحقق منه",
        icon: "warning",
        button: 'حسنا',
        footer: '<a href="contact_us.aspx">تواصل معنا لمزيد من المعلومات</a>'

    }).then(() => {

    });

}
function CheckStutUserBan() {
    Swal.fire({
        title: "فشل !",
        text: "تم حظر حسابك ",
        icon: "error",
        button: 'حسنا',
        footer: '<a href="contact_us.aspx">تواصل معنا لمزيد من المعلومات</a>'

    }).then(() => {

    });

}
function Errlog() {
    Swal.fire({
        icon: "error",
        title: "خطا...",
        text: "خطا في إدخال المعلومات!",
        footer: '<a href="#">تواصل معنا، إذا نسيت كلمة المرور</a>'
    });
}
function Wa() {
    swal("Good job!", "You clicked the button!", "success")


}
//function DoneUpdateInfoUser() {
//    swal("نجاح!", "تم التحديث بنجاح!", "success")


//}
function Error() {
    swal("خطا في النظام!", "قم بإعادة المحاولة مرة أخرى", "error");


}
function Check_email() {
    swal("خطا في الإدخال!", "بريد إلكتروني موجود مسبقا.", "warning");

}
function ChID() {
    swal("خطا في الإدخال!", "اسم مستخدم موجود مسبقا!.", "warning");

}
function ChPh() {
    swal("خطا في الإدخال!", "رقم هاتف موجود مسبقا.", "warning");

}
function CAP() {
    swal("خطا في الإدخال!", "رمز كابتشا غير صحيح.", "warning");

}

function checkFile() {
    swal("لم يتم تحميل اي ملف.", "خطا في الإدخال!", "warning");

}
function CheckPassNow() {
    swal("كلمة المرور الحالية غير صحيحة.", "خطا في الإدخال!", "warning");

}
function checkFiletype() {
    swal("صيغة الملف غير صحيحة أو حجمه كبير.", "خطا في الإدخال!", "warning");

}
function checkFileRows() {
    swal("لا يمكن تحميل فارغ", "خطا في الإدخال!", "warning");

}
function checkFileRowsAndFileImg() {
    swal(" الملف فارغ، او عدد الصفوف ليس متساوي", "خطا في الإدخال!", "warning");

}
function checkFileColum() {
    swal("عدد الأعمدة غير متطابق", "خطا في الإدخال!", "warning");

}
function CheckNameColum() {
    swal("أسماء الأعمدة غير متطابقة", "خطا في الإدخال!", "warning");

}
function CheckFAQ() {
    swal("سؤال متكرر", "خطا في الإدخال!", "warning");

}
function AddFile() {
    Swal.fire({
        position: "top-start",
        icon: "success",
        title: "تمت الإضافة بنجاح",
        showConfirmButton: false,
        timer: 1500
    });


}
function UpdateDoneSubCate() {
    // عرض الرسالة
    Swal.fire({
        position: "top-start",
        icon: "success",
        title: "تم التعديل بنجاح",
        showConfirmButton: false
    });

    // إعادة توجيه المستخدم إلى صفحة أخرى بعد 3 ثوانٍ
    setTimeout(() => {
        window.location.href = "../List/SubCategories.aspx";
    }, 1000);
}
function DoneUpdateInfoUser() {
    
    Swal.fire({
        position: "top-start",
        icon: "success",
        title: "تم التعديل بنجاح",
        showConfirmButton: false
    });

    // إعادة توجيه المستخدم إلى صفحة أخرى بعد 3 ثوانٍ
    setTimeout(() => {
        window.location.href = "/MyProfile.aspx";
    }, 1000);
}
function UpdateDoneFAQ() {
    // عرض الرسالة
    Swal.fire({
        position: "top-start",
        icon: "success",
        title: "تم التعديل بنجاح",
        showConfirmButton: false
    });

    // إعادة توجيه المستخدم إلى صفحة أخرى بعد 3 ثوانٍ
    setTimeout(() => {
        window.location.href = "../List/FAQ.aspx";
    }, 1000);
}
function UpdateDoneFAQ() {
    // عرض الرسالة
    Swal.fire({
        position: "top-start",
        icon: "success",
        title: "تم الإضافة بنجاح",
        showConfirmButton: false
    });

    // إعادة توجيه المستخدم إلى صفحة أخرى بعد 3 ثوانٍ
    setTimeout(() => {
        window.location.href = "../List/FAQ.aspx";
    }, 1000);
}
function UpdateDoneCommant() {
    // عرض الرسالة
    Swal.fire({
        position: "top-start",
        icon: "success",
        title: "تم التعديل بنجاح",
        showConfirmButton: false
    });

    // إعادة توجيه المستخدم إلى صفحة أخرى بعد 3 ثوانٍ
    setTimeout(() => {
        window.location.href = "../List/Comments.aspx";
    }, 2000);
}
function UpdateDoneFaq() {
    // عرض الرسالة
    Swal.fire({
        position: "top-start",
        icon: "success",
        title: "تم التعديل بنجاح",
        showConfirmButton: false
    });

    // إعادة توجيه المستخدم إلى صفحة أخرى بعد 3 ثوانٍ
    setTimeout(() => {
        window.location.href = "../List/FAQ.aspx";
    }, 2000);
}
function UpdateDoneimgs() {
    // عرض الرسالة
    Swal.fire({
        position: "top-start",
        icon: "success",
        title: "تم التعديل بنجاح",
        showConfirmButton: false
    });

    // إعادة توجيه المستخدم إلى صفحة أخرى بعد 3 ثوانٍ
    setTimeout(() => {
        window.location.href = "../List/Images.aspx";
    }, 1000);
}
function UpdateDoneUser() {
    // عرض الرسالة
    Swal.fire({
        position: "top-start",
        icon: "success",
        title: "تم التعديل بنجاح",
        showConfirmButton: false
    });

    // إعادة توجيه المستخدم إلى صفحة أخرى بعد 3 ثوانٍ
    setTimeout(() => {
        window.location.href = "../List/Users.aspx";
    }, 1000);
}
function AddDoneSubcate() {
    // عرض الرسالة
    Swal.fire({
        position: "top-start",
        icon: "success",
        title: "تم الإضافة بنجاح",
        showConfirmButton: false
    });

    // إعادة توجيه المستخدم إلى صفحة أخرى بعد 3 ثوانٍ
    setTimeout(() => {
        window.location.href = "../List/SubCategories.aspx";
    }, 1000);
}
function AddDoneSubImgs() {
    // عرض الرسالة
    Swal.fire({
        position: "top-start",
        icon: "success",
        title: "تم الإضافة بنجاح",
        showConfirmButton: false
    });

    // إعادة توجيه المستخدم إلى صفحة أخرى بعد 3 ثوانٍ
    setTimeout(() => {
        window.location.href = "../List/Images.aspx";
    }, 2000);
}
function AddDoneComment() {
    // عرض الرسالة
    Swal.fire({
        position: "top-start",
        icon: "success",
        title: "تم الإضافة بنجاح",
        showConfirmButton: false
    });

    // إعادة توجيه المستخدم إلى صفحة أخرى بعد 3 ثوانٍ
    setTimeout(() => {
        window.location.href = "../List/Comments.aspx";
    }, 2000);
}
function AddDoneUser() {
    // عرض الرسالة
    Swal.fire({
        position: "top-start",
        icon: "success",
        title: "تم الإضافة بنجاح",
        showConfirmButton: false
    });

    // إعادة توجيه المستخدم إلى صفحة أخرى بعد 3 ثوانٍ
    setTimeout(() => {
        window.location.href = "../List/Users.aspx";
    }, 1000);
}
function AddDoneAds() {
    // عرض الرسالة
    Swal.fire({
        position: "top-start",
        icon: "success",
        title: "تم الإضافة بنجاح",
        showConfirmButton: false
    });

    // إعادة توجيه المستخدم إلى صفحة أخرى بعد 3 ثوانٍ
    setTimeout(() => {
        window.location.href = "../List/Ads.aspx";
    }, 6000);
}
function AddDoneAdsForUser() {
    // عرض الرسالة
    Swal.fire({
        position: "center",
        icon: "success",
        title: "تم الإضافة بنجاح",
        showConfirmButton: false
    });

    // إعادة توجيه المستخدم إلى صفحة أخرى بعد 3 ثوانٍ
    setTimeout(() => {
        window.location.href = "MyProfile.aspx";
    }, 2000);
}
function EditDoneAds() {
    // عرض الرسالة
    Swal.fire({
        position: "top-start",
        icon: "success",
        title: "تم التعديل بنجاح",
        showConfirmButton: false
    });

    // إعادة توجيه المستخدم إلى صفحة أخرى بعد 3 ثوانٍ
    setTimeout(() => {
        window.location.href = "../List/Ads.aspx";
    }, 2000);
}
function EditDoneAdsForUser() {
    // عرض الرسالة
    Swal.fire({
        position: "top-start",
        icon: "success",
        title: "تم التعديل بنجاح",
        showConfirmButton: false
    });

    // إعادة توجيه المستخدم إلى صفحة أخرى بعد 3 ثوانٍ
    setTimeout(() => {
        window.location.href = "MyProfile.aspx";
    }, 2000);
}
function AddCatoger() {
    // عرض الرسالة
    Swal.fire({
        position: "top-start",
        icon: "success",
        title: "تم التعديل بنجاح",
        showConfirmButton: false
    });

    // إعادة توجيه المستخدم إلى صفحة أخرى بعد 3 ثوانٍ
    setTimeout(() => {
        window.location.href = "../List/Categories.aspx";
    }, 1000);
}
function AddCatogerDD() {
    // عرض الرسالة
    Swal.fire({
        position: "top-start",
        icon: "success",
        title: "تم الإضافة بنجاح",
        showConfirmButton: false
    });

    // إعادة توجيه المستخدم إلى صفحة أخرى بعد 3 ثوانٍ
    setTimeout(() => {
        window.location.href = "../List/Categories.aspx";
    }, 1000);
}

function UpdateDoneCate() {
    // عرض الرسالة
    Swal.fire({
        position: "top-start",
        icon: "success",
        title: "تم التعديل بنجاح",
        showConfirmButton: false
    });

    // إعادة توجيه المستخدم إلى صفحة أخرى بعد1 ثوانٍ
    setTimeout(() => {
        window.location.href = "../List/Categories.aspx";
    }, 1000);
}

function DeletefalseCate() {
    Swal.fire({
        position: "top-start",
        icon: "error",
        title: "لايمكن حدف فئة تحتوي على عناصر!",
        showConfirmButton: false,
        timer: 1500
    });


}
function DeleteMainimg() {
    Swal.fire({
        position: "top-start",
        icon: "error",
        title: "لايمكن حذف صورة رئيسية!",
        showConfirmButton: false,
        timer: 3500
    });


}
function banFalis() {
    Swal.fire({
        position: "top-start",
        icon: "error",
        title: "فشل في عملية الإيقاف!",
        showConfirmButton: false,
        timer: 1500
    });


}
function DeleteDone() {
    Swal.fire({
        position: "top-start",
        icon: "success",
        title: "تم الحذف بنجاح!",
        showConfirmButton: false,
        timer: 3500
    });


}
function BanUserLis() {
    Swal.fire({
        position: "top-start",
        icon: "success",
        title: "تم الحظر بنجاح!",
        showConfirmButton: false,
        timer: 2500
    });


}
function BanAd() {
    Swal.fire({
        position: "top-start",
        icon: "success",
        title: "تم إيقافه بنجاح!",
        showConfirmButton: false,
        timer: 2100
    });


}
function checkInfoCate() {
    swal("قم بإدخال جميع البيانات المطلوبة", "خطا في الإدخال!", "warning");

}
function CheckLengtText() {
    swal("طول النص طويل جدا", "خطا في الإدخال!", "warning");

}
function checkImgType() {
    swal("صيغة صورة غير مدعومة.", "خطا في الإدخال!", "warning");

}
function CheckPrice() {
    swal("صيغة سعر غير صحيحة", "خطا في الإدخال!", "warning");

}
function CheckName() {
    swal(" اسم موجود مسبقا.او خاطئ", "خطا في الإدخال!", "warning");

}
function CheckLenthString() {
    swal("طول النص في الوصف تجاوز الحد", "خطا في الإدخال!", "warning");

}
function CheckFileRowsEnter() {
    swal("الملف فارغ او المحتوى مكرر كامل", "خطا في الإدخال!", "warning");

}
function CheckSubimg() {
    swal("لديك مشكلة ف الصور الفرعية", "خطا في الإدخال!", "warning");

}
function CheckInfoEmailandPh() {
    swal("بريد أو رقم هاتف، مسجل مسبقا", "خطا في الإدخال!", "warning");

}