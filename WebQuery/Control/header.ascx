<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="WebQuery.Control.header" %>
<div class="Logo FL"><a href="http://www.hi1718.com"><img src="/images/search/logo.gif" width="197" height="81" alt="维库仪器仪表网"/></a></div>
<div  class="search01 FL">
       <ul id="ul1" class="searchTitle clearfix">
          <li id="sell" class="show"><a href="javascript:void(0);" onclick="">产 品</a></li>
          <li id="buy"><a href="javascript:void(0);">采 购</a></li>
          <li id="company"><a href="javascript:void(0);">公 司</a></li>
          <input type="hidden" id="searchType" value="sell" />
           <input  id="nvaselect" name="nvaselect" type="hidden" value="<%=NavSelect() %>"/>
      </ul>
        <form id="form1" onsubmit="serarchHandle.search();return false;">
           <div class="searchCon clearfix">
               <input id="txtKeyword" type="text" value="<%=this.Request["keyword"] %>" class="inp01"/>
               <input type="submit"   value="" class="searchBtn01 FL"/>
           </div>
        </form>
</div>
<div class="help"><a target="_blank" href="http://www.hi1718.com/about/contact-us.html">搜索帮助</a></div>
<div class="clear"></div>