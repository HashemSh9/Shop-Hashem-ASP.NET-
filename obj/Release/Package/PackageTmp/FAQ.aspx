<%@ Page Title="" Language="C#" MasterPageFile="~/Regst.Master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="Shop_College.FAQ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background: #f5f5f6;
            margin-top: 20px;
            direction: rtl;
            text-align: right;
        }
        /*Faq*/

        .faq-search-wrap {
            padding: 50px 0 60px;
        }

            .faq-search-wrap .form-group .form-control,
            .faq-search-wrap .form-group .dd-handle {
                border-top-right-radius: .25rem;
                border-bottom-right-radius: .25rem;
            }

            .faq-search-wrap .form-group .input-group-append {
                position: absolute;
                right: 0;
                left: 0;
                bottom: 0;
                z-index: 10;
                pointer-events: none;
            }

                .faq-search-wrap .form-group .input-group-append .input-group-text {
                    background: transparent;
                    border: none;
                }

                    .faq-search-wrap .form-group .input-group-append .input-group-text .feather-icon > svg {
                        height: 18px;
                        width: 18px;
                    }

        .bg-teal-light-3 {
            background-color: #7fcdc1 !important;
        }

        .hk-row {
            display: -ms-flexbox;
            display: flex;
            -ms-flex-wrap: wrap;
            flex-wrap: wrap;
            margin-right: -10px;
            margin-left: -10px;
        }

        @media (min-width: 576px) {
            .mt-sm-60 {
                margin-top: 60px !important;
            }
        }

        .mt-30 {
            margin-top: 30px !important;
        }

        .list-group-item.active {
            background-color: #00acf0;
            border-color: #00acf0;
        }

        .accordion .card .card-header.activestate {
            border-width: 1px;
        }

        .accordion .card .card-header {
            padding: 0;
            border-width: 0;
        }

        .card.card-lg .card-header, .card.card-lg .card-footer {
            padding: .9rem 1.5rem;
        }

        .accordion > .card .card-header {
            margin-bottom: -1px;
        }

        .card .card-header {
            background: transparent;
            border: none;
        }

        .accordion.accordion-type-2 .card .card-header > a.collapsed {
            color: #324148;
        }

        .accordion .card:first-of-type .card-header:first-child > a {
            border-top-left-radius: calc(.25rem - 1px);
            border-top-right-radius: calc(.25rem - 1px);
        }

        .accordion.accordion-type-2 .card .card-header > a {
            background: transparent;
            color: #00acf0;
            padding-right: 50px;
        }

        .accordion .card .card-header > a.collapsed {
            color: #324148;
            background: transparent;
        }

        .accordion .card .card-header > a {
            background: #00acf0;
            color: #fff;
            font-weight: 500;
            padding: .75rem 1.25rem;
            display: block;
            width: 100%;
            text-align: right;
            position: relative;
            -webkit-transition: all 0.2s ease-in-out;
            -moz-transition: all 0.2s ease-in-out;
            transition: all 0.2s ease-in-out;
        }

        a {
            text-decoration: none;
            color: #00acf0;
            -webkit-transition: color 0.2s ease;
            -moz-transition: color 0.2s ease;
            transition: color 0.2s ease;
        }


        .badge.badge-pill {
            border-radius: 50px;
        }

        .badge.badge-light {
            background: #eaecec;
            color: #324148;
        }

        .badge {
            font-weight: 500;
            border-radius: 4px;
            padding: 5px 7px;
            font-size: 72%;
            letter-spacing: 0.3px;
            vertical-align: middle;
            display: inline-block;
            text-align: center;
            text-transform: capitalize;
        }

        .ml-15 {
            margin-left: 15px !important;
        }

        .accordion.accordion-type-2 .card .card-header > a.collapsed:after {
            content: "\f158";
        }

        .accordion.accordion-type-2 .card .card-header > a::after {
            display: inline-block;
            font: normal normal normal 14px/1 'Ionicons';
            speak: none;
            text-transform: none;
            line-height: 1;
            -webkit-font-smoothing: antialiased;
            -moz-osx-font-smoothing: grayscale;
            text-rendering: auto;
            position: absolute;
            content: "\f176";
            font-size: 21px;
            top: 15px;
            right: 20px;
        }

        .mr-15 {
            margin-right: 15px !important;
        }
        .site-title {
            font-weight: 700;
            text-transform: capitalize;
            font-size: 35px;
            color: #5781e8 !important;
            margin-top: 10px;
            margin-bottom: 0;
           letter-spacing: 3px; 
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/4.2.0/css/ionicons.min.css" integrity="sha256-F3Xeb7IIFr1QsWD113kV2JXaEbjhsfpgrKkwZFGIA4E=" crossorigin="anonymous" />

    <div class="container-fluid">

        <div class="row text-center">

  <div class="col-12">

    <h3 class="site-title mb-3" >الأسئلة الشائعة</h3>

    <p class="text-secondary">
لديك أسئلة؟ لا داعي للقلق. تفضل بالتصفح للعثور على إجابات مختصرة وواضحة لكل سؤال.



    </p>

  </div>

</div>


        <!-- Row -->
        <div class="row">
            <div class="col-xl-12 pa-0">

                <div class="container mt-sm-60 mt-30">
                    <div class="hk-row">

                        <div class="col-xl-12">
                            <div class="card card-lg text-right">
                                <h4 class="card-header border-bottom-0 "style="font-size: 20px;">لأي إستفسار، الرجاء التواصل معنا
                                </h4>
                              
                                    <div class="accordion accordion-type-2 accordion-flush" id="accordion_2">
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <div class="card">
                <div class="card-header d-flex justify-content-end activestate text-right">
                    <a role="button" data-toggle="collapse" href="#collapse_<%# Container.ItemIndex %>"
                        aria-expanded="false" dir="rtl"><%# Eval("FAQ_Question") %></a>
                </div>
                <div id="collapse_<%# Container.ItemIndex %>" class="collapse" data-parent="#accordion_2"
                    role="tabpanel">
                    <div class="card-body pa-15" dir="rtl"><%# Eval("FAQ_Answer") %></div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
                               
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- /Row -->
    </div>

</asp:Content>
