  


<!DOCTYPE html>
<html>
  <head prefix="og: http://ogp.me/ns# fb: http://ogp.me/ns/fb# githubog: http://ogp.me/ns/fb/githubog#">
    <meta charset='utf-8'>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <title>JavaScriptButtons/dist/paypal-button.js at master · paypal/JavaScriptButtons</title>
    <link rel="search" type="application/opensearchdescription+xml" href="/opensearch.xml" title="GitHub" />
    <link rel="fluid-icon" href="https://github.com/fluidicon.png" title="GitHub" />
    <link rel="apple-touch-icon" sizes="57x57" href="/apple-touch-icon-114.png" />
    <link rel="apple-touch-icon" sizes="114x114" href="/apple-touch-icon-114.png" />
    <link rel="apple-touch-icon" sizes="72x72" href="/apple-touch-icon-144.png" />
    <link rel="apple-touch-icon" sizes="144x144" href="/apple-touch-icon-144.png" />
    <link rel="logo" type="image/svg" href="http://github-media-downloads.s3.amazonaws.com/github-logo.svg" />
    <link rel="assets" href="https://a248.e.akamai.net/assets.github.com/">
    <link rel="xhr-socket" href="/_sockets" />
    


    <meta name="msapplication-TileImage" content="/windows-tile.png" />
    <meta name="msapplication-TileColor" content="#ffffff" />
    <meta name="selected-link" value="repo_source" data-pjax-transient />
    <meta content="collector.githubapp.com" name="octolytics-host" /><meta content="github" name="octolytics-app-id" /><meta content="1138321" name="octolytics-actor-id" /><meta content="PedroOsimani" name="octolytics-actor-login" /><meta content="536c7d3cb526afd5eeb1a321379a1ac4d3b55c018105662a5159c05113c09ecc" name="octolytics-actor-hash" />

    
    
    <link rel="icon" type="image/x-icon" href="/favicon.ico" />

    <meta content="authenticity_token" name="csrf-param" />
<meta content="PxEnq0yxslVZfaE6PhcrTkq7sDS58Fi9fgH6R9f53Uc=" name="csrf-token" />

    <link href="https://a248.e.akamai.net/assets.github.com/assets/github-a4c524f2138ecc4dd5bf9b8a6b1517bf38aa7b65.css" media="all" rel="stylesheet" type="text/css" />
    <link href="https://a248.e.akamai.net/assets.github.com/assets/github2-90ab6d28026c957cc4eb3342b1512f4c4737ede5.css" media="all" rel="stylesheet" type="text/css" />
    


      <script src="https://a248.e.akamai.net/assets.github.com/assets/frameworks-5c60c478b1e0f90d149f11ed15aa52edd2996882.js" type="text/javascript"></script>
      <script src="https://a248.e.akamai.net/assets.github.com/assets/github-430dbe78e7a63605d5824fdf0715988079b9d090.js" type="text/javascript"></script>
      
      <meta http-equiv="x-pjax-version" content="e18e090ecc98d3d0f1b30ee3406862bb">

        <link data-pjax-transient rel='permalink' href='/paypal/JavaScriptButtons/blob/c09ee4d8d2b3020330b3215233681dcbd373ef2e/dist/paypal-button.js'>
    <meta property="og:title" content="JavaScriptButtons"/>
    <meta property="og:type" content="githubog:gitrepository"/>
    <meta property="og:url" content="https://github.com/paypal/JavaScriptButtons"/>
    <meta property="og:image" content="https://secure.gravatar.com/avatar/c07568415ce496ef2fae2002493cfd28?s=420&amp;d=https://a248.e.akamai.net/assets.github.com%2Fimages%2Fgravatars%2Fgravatar-user-420.png"/>
    <meta property="og:site_name" content="GitHub"/>
    <meta property="og:description" content="JavaScriptButtons - JavaScript for creating dynamic buttons that enable PayPal checkout"/>
    <meta property="twitter:card" content="summary"/>
    <meta property="twitter:site" content="@GitHub">
    <meta property="twitter:title" content="paypal/JavaScriptButtons"/>

    <meta name="description" content="JavaScriptButtons - JavaScript for creating dynamic buttons that enable PayPal checkout" />


    <meta content="476675" name="octolytics-dimension-user_id" /><meta content="paypal" name="octolytics-dimension-user_login" /><meta content="6712812" name="octolytics-dimension-repository_id" /><meta content="paypal/JavaScriptButtons" name="octolytics-dimension-repository_nwo" /><meta content="true" name="octolytics-dimension-repository_public" /><meta content="false" name="octolytics-dimension-repository_is_fork" /><meta content="6712812" name="octolytics-dimension-repository_network_root_id" /><meta content="paypal/JavaScriptButtons" name="octolytics-dimension-repository_network_root_nwo" />
  <link href="https://github.com/paypal/JavaScriptButtons/commits/master.atom" rel="alternate" title="Recent Commits to JavaScriptButtons:master" type="application/atom+xml" />

  </head>


  <body class="logged_in page-blob windows vis-public env-production  ">
    <div id="wrapper">

      
      
      

      <div class="header header-logged-in true">
  <div class="container clearfix">

    <a class="header-logo-invertocat" href="https://github.com/">
  <span class="mega-octicon octicon-mark-github"></span>
</a>

    <div class="divider-vertical"></div>

      <a href="/notifications" class="notification-indicator tooltipped downwards" title="You have no unread notifications">
    <span class="mail-status all-read"></span>
  </a>
  <div class="divider-vertical"></div>


      <div class="command-bar js-command-bar  in-repository">
          <form accept-charset="UTF-8" action="/search" class="command-bar-form" id="top_search_form" method="get">
  <a href="/search/advanced" class="advanced-search-icon tooltipped downwards command-bar-search" id="advanced_search" title="Advanced search"><span class="octicon octicon-gear "></span></a>

  <input type="text" data-hotkey="/ s" name="q" id="js-command-bar-field" placeholder="Search or type a command" tabindex="1" autocapitalize="off"
    data-username="PedroOsimani"
      data-repo="paypal/JavaScriptButtons"
      data-branch="master"
      data-sha="b9c7a912aee9fe13a1db81beb34349584b54cc66"
  >

    <input type="hidden" name="nwo" value="paypal/JavaScriptButtons" />

    <div class="select-menu js-menu-container js-select-menu search-context-select-menu">
      <span class="minibutton select-menu-button js-menu-target">
        <span class="js-select-button">This repository</span>
      </span>

      <div class="select-menu-modal-holder js-menu-content js-navigation-container">
        <div class="select-menu-modal">

          <div class="select-menu-item js-navigation-item selected">
            <span class="select-menu-item-icon octicon octicon-check"></span>
            <input type="radio" class="js-search-this-repository" name="search_target" value="repository" checked="checked" />
            <div class="select-menu-item-text js-select-button-text">This repository</div>
          </div> <!-- /.select-menu-item -->

          <div class="select-menu-item js-navigation-item">
            <span class="select-menu-item-icon octicon octicon-check"></span>
            <input type="radio" name="search_target" value="global" />
            <div class="select-menu-item-text js-select-button-text">All repositories</div>
          </div> <!-- /.select-menu-item -->

        </div>
      </div>
    </div>

  <span class="octicon help tooltipped downwards" title="Show command bar help">
    <span class="octicon octicon-question"></span>
  </span>


  <input type="hidden" name="ref" value="cmdform">

  <div class="divider-vertical"></div>

</form>
        <ul class="top-nav">
            <li class="explore"><a href="/explore">Explore</a></li>
            <li><a href="https://gist.github.com">Gist</a></li>
            <li><a href="/blog">Blog</a></li>
          <li><a href="http://help.github.com">Help</a></li>
        </ul>
      </div>

    

  

    <ul id="user-links">
      <li>
        <a href="/PedroOsimani" class="name">
          <img height="20" src="https://secure.gravatar.com/avatar/c090567b41157eb598c010dc2e6395a3?s=140&amp;d=https://a248.e.akamai.net/assets.github.com%2Fimages%2Fgravatars%2Fgravatar-user-420.png" width="20" /> PedroOsimani
        </a>
      </li>

        <li>
          <a href="/new" id="new_repo" class="tooltipped downwards" title="Create a new repo">
            <span class="octicon octicon-repo-create"></span>
          </a>
        </li>

        <li>
          <a href="/settings/profile" id="account_settings"
            class="tooltipped downwards"
            title="Account settings (You have no verified emails)">
            <span class="octicon octicon-tools"></span>
          </a>
            <span class="settings-warning">!</span>
        </li>
        <li>
          <a class="tooltipped downwards" href="/logout" data-method="post" id="logout" title="Sign out">
            <span class="octicon octicon-log-out"></span>
          </a>
        </li>

    </ul>


<div class="js-new-dropdown-contents hidden">
  <ul class="dropdown-menu">
    <li>
      <a href="/new"><span class="octicon octicon-repo-create"></span> New repository</a>
    </li>
    <li>
        <a href="/paypal/JavaScriptButtons/issues/new"><span class="octicon octicon-issue-opened"></span> New issue</a>
    </li>
    <li>
    </li>
    <li>
      <a href="/organizations/new"><span class="octicon octicon-list-unordered"></span> New organization</a>
    </li>
  </ul>
</div>


    
  </div>
</div>

      

      <div class="global-notice warn"><div class="global-notice-inner"><h2>You don't have any verified emails.  We recommend <a href="https://github.com/settings/emails">verifying</a> at least one email.</h2><p>Email verification will help our support team help you in case you have any email issues or lose your password.</p></div></div>


            <div class="site hfeed" itemscope itemtype="http://schema.org/WebPage">
      <div class="hentry">
        
        <div class="pagehead repohead instapaper_ignore readability-menu ">
          <div class="container">
            <div class="title-actions-bar">
              

<ul class="pagehead-actions">


    <li class="subscription">
      <form accept-charset="UTF-8" action="/notifications/subscribe" data-autosubmit="true" data-remote="true" method="post"><div style="margin:0;padding:0;display:inline"><input name="authenticity_token" type="hidden" value="PxEnq0yxslVZfaE6PhcrTkq7sDS58Fi9fgH6R9f53Uc=" /></div>  <input id="repository_id" name="repository_id" type="hidden" value="6712812" />

    <div class="select-menu js-menu-container js-select-menu">
      <span class="minibutton select-menu-button js-menu-target">
        <span class="js-select-button">
          <span class="octicon octicon-eye-watch"></span>
          Watch
        </span>
      </span>

      <div class="select-menu-modal-holder js-menu-content">
        <div class="select-menu-modal">
          <div class="select-menu-header">
            <span class="select-menu-title">Notification status</span>
            <span class="octicon octicon-remove-close js-menu-close"></span>
          </div> <!-- /.select-menu-header -->

          <div class="select-menu-list js-navigation-container">

            <div class="select-menu-item js-navigation-item selected">
              <span class="select-menu-item-icon octicon octicon-check"></span>
              <div class="select-menu-item-text">
                <input checked="checked" id="do_included" name="do" type="radio" value="included" />
                <h4>Not watching</h4>
                <span class="description">You only receive notifications for discussions in which you participate or are @mentioned.</span>
                <span class="js-select-button-text hidden-select-button-text">
                  <span class="octicon octicon-eye-watch"></span>
                  Watch
                </span>
              </div>
            </div> <!-- /.select-menu-item -->

            <div class="select-menu-item js-navigation-item ">
              <span class="select-menu-item-icon octicon octicon octicon-check"></span>
              <div class="select-menu-item-text">
                <input id="do_subscribed" name="do" type="radio" value="subscribed" />
                <h4>Watching</h4>
                <span class="description">You receive notifications for all discussions in this repository.</span>
                <span class="js-select-button-text hidden-select-button-text">
                  <span class="octicon octicon-eye-unwatch"></span>
                  Unwatch
                </span>
              </div>
            </div> <!-- /.select-menu-item -->

            <div class="select-menu-item js-navigation-item ">
              <span class="select-menu-item-icon octicon octicon-check"></span>
              <div class="select-menu-item-text">
                <input id="do_ignore" name="do" type="radio" value="ignore" />
                <h4>Ignoring</h4>
                <span class="description">You do not receive any notifications for discussions in this repository.</span>
                <span class="js-select-button-text hidden-select-button-text">
                  <span class="octicon octicon-mute"></span>
                  Stop ignoring
                </span>
              </div>
            </div> <!-- /.select-menu-item -->

          </div> <!-- /.select-menu-list -->

        </div> <!-- /.select-menu-modal -->
      </div> <!-- /.select-menu-modal-holder -->
    </div> <!-- /.select-menu -->

</form>
    </li>

    <li class="js-toggler-container js-social-container starring-container ">
      <a href="/paypal/JavaScriptButtons/unstar" class="minibutton js-toggler-target star-button starred upwards" title="Unstar this repo" data-remote="true" data-method="post" rel="nofollow">
        <span class="octicon octicon-star-delete"></span>
        <span class="text">Unstar</span>
      </a>
      <a href="/paypal/JavaScriptButtons/star" class="minibutton js-toggler-target star-button unstarred upwards" title="Star this repo" data-remote="true" data-method="post" rel="nofollow">
        <span class="octicon octicon-star"></span>
        <span class="text">Star</span>
      </a>
      <a class="social-count js-social-count" href="/paypal/JavaScriptButtons/stargazers">58</a>
    </li>

        <li>
          <a href="/paypal/JavaScriptButtons/fork" class="minibutton js-toggler-target fork-button lighter upwards" title="Fork this repo" rel="nofollow" data-method="post">
            <span class="octicon octicon-git-branch-create"></span>
            <span class="text">Fork</span>
          </a>
          <a href="/paypal/JavaScriptButtons/network" class="social-count">142</a>
        </li>


</ul>

              <h1 itemscope itemtype="http://data-vocabulary.org/Breadcrumb" class="entry-title public">
                <span class="repo-label"><span>public</span></span>
                <span class="mega-octicon octicon-repo"></span>
                <span class="author vcard">
                  <a href="/paypal" class="url fn" itemprop="url" rel="author">
                  <span itemprop="title">paypal</span>
                  </a></span> /
                <strong><a href="/paypal/JavaScriptButtons" class="js-current-repository">JavaScriptButtons</a></strong>
              </h1>
            </div>

            
  <ul class="tabs">
    <li class="pulse-nav"><a href="/paypal/JavaScriptButtons/pulse" class="js-selected-navigation-item " data-selected-links="pulse /paypal/JavaScriptButtons/pulse" rel="nofollow"><span class="octicon octicon-pulse"></span></a></li>
    <li><a href="/paypal/JavaScriptButtons" class="js-selected-navigation-item selected" data-selected-links="repo_source repo_downloads repo_commits repo_tags repo_branches /paypal/JavaScriptButtons">Code</a></li>
    <li><a href="/paypal/JavaScriptButtons/network" class="js-selected-navigation-item " data-selected-links="repo_network /paypal/JavaScriptButtons/network">Network</a></li>
    <li><a href="/paypal/JavaScriptButtons/pulls" class="js-selected-navigation-item " data-selected-links="repo_pulls /paypal/JavaScriptButtons/pulls">Pull Requests <span class='counter'>0</span></a></li>

      <li><a href="/paypal/JavaScriptButtons/issues" class="js-selected-navigation-item " data-selected-links="repo_issues /paypal/JavaScriptButtons/issues">Issues <span class='counter'>5</span></a></li>



    <li><a href="/paypal/JavaScriptButtons/graphs" class="js-selected-navigation-item " data-selected-links="repo_graphs repo_contributors /paypal/JavaScriptButtons/graphs">Graphs</a></li>


  </ul>
  
<div class="tabnav">

  <span class="tabnav-right">
    <ul class="tabnav-tabs">
          <li><a href="/paypal/JavaScriptButtons/tags" class="js-selected-navigation-item tabnav-tab" data-selected-links="repo_tags /paypal/JavaScriptButtons/tags">Tags <span class="counter ">2</span></a></li>
    </ul>
  </span>

  <div class="tabnav-widget scope">


    <div class="select-menu js-menu-container js-select-menu js-branch-menu">
      <a class="minibutton select-menu-button js-menu-target" data-hotkey="w" data-ref="master">
        <span class="octicon octicon-git-branch"></span>
        <i>branch:</i>
        <span class="js-select-button">master</span>
      </a>

      <div class="select-menu-modal-holder js-menu-content js-navigation-container">

        <div class="select-menu-modal">
          <div class="select-menu-header">
            <span class="select-menu-title">Switch branches/tags</span>
            <span class="octicon octicon-remove-close js-menu-close"></span>
          </div> <!-- /.select-menu-header -->

          <div class="select-menu-filters">
            <div class="select-menu-text-filter">
              <input type="text" id="commitish-filter-field" class="js-filterable-field js-navigation-enable" placeholder="Filter branches/tags">
            </div>
            <div class="select-menu-tabs">
              <ul>
                <li class="select-menu-tab">
                  <a href="#" data-tab-filter="branches" class="js-select-menu-tab">Branches</a>
                </li>
                <li class="select-menu-tab">
                  <a href="#" data-tab-filter="tags" class="js-select-menu-tab">Tags</a>
                </li>
              </ul>
            </div><!-- /.select-menu-tabs -->
          </div><!-- /.select-menu-filters -->

          <div class="select-menu-list select-menu-tab-bucket js-select-menu-tab-bucket css-truncate" data-tab-filter="branches">

            <div data-filterable-for="commitish-filter-field" data-filterable-type="substring">

                <div class="select-menu-item js-navigation-item ">
                  <span class="select-menu-item-icon octicon octicon-check"></span>
                  <a href="/paypal/JavaScriptButtons/blob/css-buttons/dist/paypal-button.js" class="js-navigation-open select-menu-item-text js-select-button-text css-truncate-target" data-name="css-buttons" rel="nofollow" title="css-buttons">css-buttons</a>
                </div> <!-- /.select-menu-item -->
                <div class="select-menu-item js-navigation-item ">
                  <span class="select-menu-item-icon octicon octicon-check"></span>
                  <a href="/paypal/JavaScriptButtons/blob/gh-pages/dist/paypal-button.js" class="js-navigation-open select-menu-item-text js-select-button-text css-truncate-target" data-name="gh-pages" rel="nofollow" title="gh-pages">gh-pages</a>
                </div> <!-- /.select-menu-item -->
                <div class="select-menu-item js-navigation-item selected">
                  <span class="select-menu-item-icon octicon octicon-check"></span>
                  <a href="/paypal/JavaScriptButtons/blob/master/dist/paypal-button.js" class="js-navigation-open select-menu-item-text js-select-button-text css-truncate-target" data-name="master" rel="nofollow" title="master">master</a>
                </div> <!-- /.select-menu-item -->
            </div>

              <div class="select-menu-no-results">Nothing to show</div>
          </div> <!-- /.select-menu-list -->


          <div class="select-menu-list select-menu-tab-bucket js-select-menu-tab-bucket css-truncate" data-tab-filter="tags">
            <div data-filterable-for="commitish-filter-field" data-filterable-type="substring">

                <div class="select-menu-item js-navigation-item ">
                  <span class="select-menu-item-icon octicon octicon-check"></span>
                  <a href="/paypal/JavaScriptButtons/blob/0.9.1/dist/paypal-button.js" class="js-navigation-open select-menu-item-text js-select-button-text css-truncate-target" data-name="0.9.1" rel="nofollow" title="0.9.1">0.9.1</a>
                </div> <!-- /.select-menu-item -->
                <div class="select-menu-item js-navigation-item ">
                  <span class="select-menu-item-icon octicon octicon-check"></span>
                  <a href="/paypal/JavaScriptButtons/blob/0.9/dist/paypal-button.js" class="js-navigation-open select-menu-item-text js-select-button-text css-truncate-target" data-name="0.9" rel="nofollow" title="0.9">0.9</a>
                </div> <!-- /.select-menu-item -->
            </div>

            <div class="select-menu-no-results">Nothing to show</div>

          </div> <!-- /.select-menu-list -->

        </div> <!-- /.select-menu-modal -->
      </div> <!-- /.select-menu-modal-holder -->
    </div> <!-- /.select-menu -->

  </div> <!-- /.scope -->

  <ul class="tabnav-tabs">
    <li><a href="/paypal/JavaScriptButtons" class="selected js-selected-navigation-item tabnav-tab" data-selected-links="repo_source /paypal/JavaScriptButtons">Files</a></li>
    <li><a href="/paypal/JavaScriptButtons/commits/master" class="js-selected-navigation-item tabnav-tab" data-selected-links="repo_commits /paypal/JavaScriptButtons/commits/master">Commits</a></li>
    <li><a href="/paypal/JavaScriptButtons/branches" class="js-selected-navigation-item tabnav-tab" data-selected-links="repo_branches /paypal/JavaScriptButtons/branches" rel="nofollow">Branches <span class="counter ">3</span></a></li>
  </ul>

</div>

  
  
  


            
          </div>
        </div><!-- /.repohead -->

        <div id="js-repo-pjax-container" class="container context-loader-container" data-pjax-container>
          


<!-- blob contrib key: blob_contributors:v21:e7148fdfb5420353fb30aaacef0b7a99 -->
<!-- blob contrib frag key: views10/v8/blob_contributors:v21:e7148fdfb5420353fb30aaacef0b7a99 -->


<div id="slider">
    <div class="frame-meta">

      <p title="This is a placeholder element" class="js-history-link-replace hidden"></p>

        <div class="breadcrumb">
          <span class='bold'><span itemscope="" itemtype="http://data-vocabulary.org/Breadcrumb"><a href="/paypal/JavaScriptButtons" class="js-slide-to" data-branch="master" data-direction="back" itemscope="url"><span itemprop="title">JavaScriptButtons</span></a></span></span><span class="separator"> / </span><span itemscope="" itemtype="http://data-vocabulary.org/Breadcrumb"><a href="/paypal/JavaScriptButtons/tree/master/dist" class="js-slide-to" data-branch="master" data-direction="back" itemscope="url"><span itemprop="title">dist</span></a></span><span class="separator"> / </span><strong class="final-path">paypal-button.js</strong> <span class="js-zeroclipboard zeroclipboard-button" data-clipboard-text="dist/paypal-button.js" data-copied-hint="copied!" title="copy to clipboard"><span class="octicon octicon-clippy"></span></span>
        </div>

      <a href="/paypal/JavaScriptButtons/find/master" class="js-slide-to" data-hotkey="t" style="display:none">Show File Finder</a>


        
  <div class="commit file-history-tease">
    <img class="main-avatar" height="24" src="https://secure.gravatar.com/avatar/fcff4657d7569f605976d2cab3813890?s=140&amp;d=https://a248.e.akamai.net/assets.github.com%2Fimages%2Fgravatars%2Fgravatar-user-420.png" width="24" />
    <span class="author"><a href="/cbetta" rel="author">cbetta</a></span>
    <time class="js-relative-date" datetime="2013-05-06T16:25:21-07:00" title="2013-05-06 16:25:21">May 06, 2013</time>
    <div class="commit-title">
        <a href="/paypal/JavaScriptButtons/commit/5d57a4e72791d0cf840ef588f0263fe2ddc464a0" class="message">Merge remote-tracking branch 'upstream/master' into fix_sandbox_url</a>
    </div>

    <div class="participation">
      <p class="quickstat"><a href="#blob_contributors_box" rel="facebox"><strong>4</strong> contributors</a></p>
          <a class="avatar tooltipped downwards" title="cbetta" href="/paypal/JavaScriptButtons/commits/master/dist/paypal-button.js?author=cbetta"><img height="20" src="https://secure.gravatar.com/avatar/fcff4657d7569f605976d2cab3813890?s=140&amp;d=https://a248.e.akamai.net/assets.github.com%2Fimages%2Fgravatars%2Fgravatar-user-420.png" width="20" /></a>
    <a class="avatar tooltipped downwards" title="jeffharrell" href="/paypal/JavaScriptButtons/commits/master/dist/paypal-button.js?author=jeffharrell"><img height="20" src="https://secure.gravatar.com/avatar/51f29c3cc9cbc23902c6c59581349d39?s=140&amp;d=https://a248.e.akamai.net/assets.github.com%2Fimages%2Fgravatars%2Fgravatar-user-420.png" width="20" /></a>
    <a class="avatar tooltipped downwards" title="mstuart" href="/paypal/JavaScriptButtons/commits/master/dist/paypal-button.js?author=mstuart"><img height="20" src="https://secure.gravatar.com/avatar/ec16728a8e4618dfd55b73dcc55c8beb?s=140&amp;d=https://a248.e.akamai.net/assets.github.com%2Fimages%2Fgravatars%2Fgravatar-user-420.png" width="20" /></a>
    <a class="avatar tooltipped downwards" title="SeraphimSerapis" href="/paypal/JavaScriptButtons/commits/master/dist/paypal-button.js?author=SeraphimSerapis"><img height="20" src="https://secure.gravatar.com/avatar/15da5ebc4b9845f12a3d7b111fcf9eaf?s=140&amp;d=https://a248.e.akamai.net/assets.github.com%2Fimages%2Fgravatars%2Fgravatar-user-420.png" width="20" /></a>


    </div>
    <div id="blob_contributors_box" style="display:none">
      <h2>Users on GitHub who have contributed to this file</h2>
      <ul class="facebox-user-list">
        <li>
          <img height="24" src="https://secure.gravatar.com/avatar/fcff4657d7569f605976d2cab3813890?s=140&amp;d=https://a248.e.akamai.net/assets.github.com%2Fimages%2Fgravatars%2Fgravatar-user-420.png" width="24" />
          <a href="/cbetta">cbetta</a>
        </li>
        <li>
          <img height="24" src="https://secure.gravatar.com/avatar/51f29c3cc9cbc23902c6c59581349d39?s=140&amp;d=https://a248.e.akamai.net/assets.github.com%2Fimages%2Fgravatars%2Fgravatar-user-420.png" width="24" />
          <a href="/jeffharrell">jeffharrell</a>
        </li>
        <li>
          <img height="24" src="https://secure.gravatar.com/avatar/ec16728a8e4618dfd55b73dcc55c8beb?s=140&amp;d=https://a248.e.akamai.net/assets.github.com%2Fimages%2Fgravatars%2Fgravatar-user-420.png" width="24" />
          <a href="/mstuart">mstuart</a>
        </li>
        <li>
          <img height="24" src="https://secure.gravatar.com/avatar/15da5ebc4b9845f12a3d7b111fcf9eaf?s=140&amp;d=https://a248.e.akamai.net/assets.github.com%2Fimages%2Fgravatars%2Fgravatar-user-420.png" width="24" />
          <a href="/SeraphimSerapis">SeraphimSerapis</a>
        </li>
      </ul>
    </div>
  </div>


    </div><!-- ./.frame-meta -->

    <div class="frames">
      <div class="frame" data-permalink-url="/paypal/JavaScriptButtons/blob/c09ee4d8d2b3020330b3215233681dcbd373ef2e/dist/paypal-button.js" data-title="JavaScriptButtons/dist/paypal-button.js at master · paypal/JavaScriptButtons · GitHub" data-type="blob">

        <div id="files" class="bubble">
          <div class="file">
            <div class="meta">
              <div class="info">
                <span class="icon"><b class="octicon octicon-file-text"></b></span>
                <span class="mode" title="File Mode">file</span>
                  <span>383 lines (309 sloc)</span>
                <span>14.749 kb</span>
              </div>
              <div class="actions">
                <div class="button-group">
                        <a class="minibutton tooltipped leftwards"
                           title="Clicking this button will automatically fork this project so you can edit the file"
                           href="/paypal/JavaScriptButtons/edit/master/dist/paypal-button.js"
                           data-method="post" rel="nofollow">Edit</a>
                  <a href="/paypal/JavaScriptButtons/raw/master/dist/paypal-button.js" class="button minibutton " id="raw-url">Raw</a>
                    <a href="/paypal/JavaScriptButtons/blame/master/dist/paypal-button.js" class="button minibutton ">Blame</a>
                  <a href="/paypal/JavaScriptButtons/commits/master/dist/paypal-button.js" class="button minibutton " rel="nofollow">History</a>
                </div><!-- /.button-group -->
              </div><!-- /.actions -->

            </div>
                <div class="blob-wrapper data type-javascript js-blob-data">
      <table class="file-code file-diff">
        <tr class="file-code-line">
          <td class="blob-line-nums">
            <span id="L1" rel="#L1">1</span>
<span id="L2" rel="#L2">2</span>
<span id="L3" rel="#L3">3</span>
<span id="L4" rel="#L4">4</span>
<span id="L5" rel="#L5">5</span>
<span id="L6" rel="#L6">6</span>
<span id="L7" rel="#L7">7</span>
<span id="L8" rel="#L8">8</span>
<span id="L9" rel="#L9">9</span>
<span id="L10" rel="#L10">10</span>
<span id="L11" rel="#L11">11</span>
<span id="L12" rel="#L12">12</span>
<span id="L13" rel="#L13">13</span>
<span id="L14" rel="#L14">14</span>
<span id="L15" rel="#L15">15</span>
<span id="L16" rel="#L16">16</span>
<span id="L17" rel="#L17">17</span>
<span id="L18" rel="#L18">18</span>
<span id="L19" rel="#L19">19</span>
<span id="L20" rel="#L20">20</span>
<span id="L21" rel="#L21">21</span>
<span id="L22" rel="#L22">22</span>
<span id="L23" rel="#L23">23</span>
<span id="L24" rel="#L24">24</span>
<span id="L25" rel="#L25">25</span>
<span id="L26" rel="#L26">26</span>
<span id="L27" rel="#L27">27</span>
<span id="L28" rel="#L28">28</span>
<span id="L29" rel="#L29">29</span>
<span id="L30" rel="#L30">30</span>
<span id="L31" rel="#L31">31</span>
<span id="L32" rel="#L32">32</span>
<span id="L33" rel="#L33">33</span>
<span id="L34" rel="#L34">34</span>
<span id="L35" rel="#L35">35</span>
<span id="L36" rel="#L36">36</span>
<span id="L37" rel="#L37">37</span>
<span id="L38" rel="#L38">38</span>
<span id="L39" rel="#L39">39</span>
<span id="L40" rel="#L40">40</span>
<span id="L41" rel="#L41">41</span>
<span id="L42" rel="#L42">42</span>
<span id="L43" rel="#L43">43</span>
<span id="L44" rel="#L44">44</span>
<span id="L45" rel="#L45">45</span>
<span id="L46" rel="#L46">46</span>
<span id="L47" rel="#L47">47</span>
<span id="L48" rel="#L48">48</span>
<span id="L49" rel="#L49">49</span>
<span id="L50" rel="#L50">50</span>
<span id="L51" rel="#L51">51</span>
<span id="L52" rel="#L52">52</span>
<span id="L53" rel="#L53">53</span>
<span id="L54" rel="#L54">54</span>
<span id="L55" rel="#L55">55</span>
<span id="L56" rel="#L56">56</span>
<span id="L57" rel="#L57">57</span>
<span id="L58" rel="#L58">58</span>
<span id="L59" rel="#L59">59</span>
<span id="L60" rel="#L60">60</span>
<span id="L61" rel="#L61">61</span>
<span id="L62" rel="#L62">62</span>
<span id="L63" rel="#L63">63</span>
<span id="L64" rel="#L64">64</span>
<span id="L65" rel="#L65">65</span>
<span id="L66" rel="#L66">66</span>
<span id="L67" rel="#L67">67</span>
<span id="L68" rel="#L68">68</span>
<span id="L69" rel="#L69">69</span>
<span id="L70" rel="#L70">70</span>
<span id="L71" rel="#L71">71</span>
<span id="L72" rel="#L72">72</span>
<span id="L73" rel="#L73">73</span>
<span id="L74" rel="#L74">74</span>
<span id="L75" rel="#L75">75</span>
<span id="L76" rel="#L76">76</span>
<span id="L77" rel="#L77">77</span>
<span id="L78" rel="#L78">78</span>
<span id="L79" rel="#L79">79</span>
<span id="L80" rel="#L80">80</span>
<span id="L81" rel="#L81">81</span>
<span id="L82" rel="#L82">82</span>
<span id="L83" rel="#L83">83</span>
<span id="L84" rel="#L84">84</span>
<span id="L85" rel="#L85">85</span>
<span id="L86" rel="#L86">86</span>
<span id="L87" rel="#L87">87</span>
<span id="L88" rel="#L88">88</span>
<span id="L89" rel="#L89">89</span>
<span id="L90" rel="#L90">90</span>
<span id="L91" rel="#L91">91</span>
<span id="L92" rel="#L92">92</span>
<span id="L93" rel="#L93">93</span>
<span id="L94" rel="#L94">94</span>
<span id="L95" rel="#L95">95</span>
<span id="L96" rel="#L96">96</span>
<span id="L97" rel="#L97">97</span>
<span id="L98" rel="#L98">98</span>
<span id="L99" rel="#L99">99</span>
<span id="L100" rel="#L100">100</span>
<span id="L101" rel="#L101">101</span>
<span id="L102" rel="#L102">102</span>
<span id="L103" rel="#L103">103</span>
<span id="L104" rel="#L104">104</span>
<span id="L105" rel="#L105">105</span>
<span id="L106" rel="#L106">106</span>
<span id="L107" rel="#L107">107</span>
<span id="L108" rel="#L108">108</span>
<span id="L109" rel="#L109">109</span>
<span id="L110" rel="#L110">110</span>
<span id="L111" rel="#L111">111</span>
<span id="L112" rel="#L112">112</span>
<span id="L113" rel="#L113">113</span>
<span id="L114" rel="#L114">114</span>
<span id="L115" rel="#L115">115</span>
<span id="L116" rel="#L116">116</span>
<span id="L117" rel="#L117">117</span>
<span id="L118" rel="#L118">118</span>
<span id="L119" rel="#L119">119</span>
<span id="L120" rel="#L120">120</span>
<span id="L121" rel="#L121">121</span>
<span id="L122" rel="#L122">122</span>
<span id="L123" rel="#L123">123</span>
<span id="L124" rel="#L124">124</span>
<span id="L125" rel="#L125">125</span>
<span id="L126" rel="#L126">126</span>
<span id="L127" rel="#L127">127</span>
<span id="L128" rel="#L128">128</span>
<span id="L129" rel="#L129">129</span>
<span id="L130" rel="#L130">130</span>
<span id="L131" rel="#L131">131</span>
<span id="L132" rel="#L132">132</span>
<span id="L133" rel="#L133">133</span>
<span id="L134" rel="#L134">134</span>
<span id="L135" rel="#L135">135</span>
<span id="L136" rel="#L136">136</span>
<span id="L137" rel="#L137">137</span>
<span id="L138" rel="#L138">138</span>
<span id="L139" rel="#L139">139</span>
<span id="L140" rel="#L140">140</span>
<span id="L141" rel="#L141">141</span>
<span id="L142" rel="#L142">142</span>
<span id="L143" rel="#L143">143</span>
<span id="L144" rel="#L144">144</span>
<span id="L145" rel="#L145">145</span>
<span id="L146" rel="#L146">146</span>
<span id="L147" rel="#L147">147</span>
<span id="L148" rel="#L148">148</span>
<span id="L149" rel="#L149">149</span>
<span id="L150" rel="#L150">150</span>
<span id="L151" rel="#L151">151</span>
<span id="L152" rel="#L152">152</span>
<span id="L153" rel="#L153">153</span>
<span id="L154" rel="#L154">154</span>
<span id="L155" rel="#L155">155</span>
<span id="L156" rel="#L156">156</span>
<span id="L157" rel="#L157">157</span>
<span id="L158" rel="#L158">158</span>
<span id="L159" rel="#L159">159</span>
<span id="L160" rel="#L160">160</span>
<span id="L161" rel="#L161">161</span>
<span id="L162" rel="#L162">162</span>
<span id="L163" rel="#L163">163</span>
<span id="L164" rel="#L164">164</span>
<span id="L165" rel="#L165">165</span>
<span id="L166" rel="#L166">166</span>
<span id="L167" rel="#L167">167</span>
<span id="L168" rel="#L168">168</span>
<span id="L169" rel="#L169">169</span>
<span id="L170" rel="#L170">170</span>
<span id="L171" rel="#L171">171</span>
<span id="L172" rel="#L172">172</span>
<span id="L173" rel="#L173">173</span>
<span id="L174" rel="#L174">174</span>
<span id="L175" rel="#L175">175</span>
<span id="L176" rel="#L176">176</span>
<span id="L177" rel="#L177">177</span>
<span id="L178" rel="#L178">178</span>
<span id="L179" rel="#L179">179</span>
<span id="L180" rel="#L180">180</span>
<span id="L181" rel="#L181">181</span>
<span id="L182" rel="#L182">182</span>
<span id="L183" rel="#L183">183</span>
<span id="L184" rel="#L184">184</span>
<span id="L185" rel="#L185">185</span>
<span id="L186" rel="#L186">186</span>
<span id="L187" rel="#L187">187</span>
<span id="L188" rel="#L188">188</span>
<span id="L189" rel="#L189">189</span>
<span id="L190" rel="#L190">190</span>
<span id="L191" rel="#L191">191</span>
<span id="L192" rel="#L192">192</span>
<span id="L193" rel="#L193">193</span>
<span id="L194" rel="#L194">194</span>
<span id="L195" rel="#L195">195</span>
<span id="L196" rel="#L196">196</span>
<span id="L197" rel="#L197">197</span>
<span id="L198" rel="#L198">198</span>
<span id="L199" rel="#L199">199</span>
<span id="L200" rel="#L200">200</span>
<span id="L201" rel="#L201">201</span>
<span id="L202" rel="#L202">202</span>
<span id="L203" rel="#L203">203</span>
<span id="L204" rel="#L204">204</span>
<span id="L205" rel="#L205">205</span>
<span id="L206" rel="#L206">206</span>
<span id="L207" rel="#L207">207</span>
<span id="L208" rel="#L208">208</span>
<span id="L209" rel="#L209">209</span>
<span id="L210" rel="#L210">210</span>
<span id="L211" rel="#L211">211</span>
<span id="L212" rel="#L212">212</span>
<span id="L213" rel="#L213">213</span>
<span id="L214" rel="#L214">214</span>
<span id="L215" rel="#L215">215</span>
<span id="L216" rel="#L216">216</span>
<span id="L217" rel="#L217">217</span>
<span id="L218" rel="#L218">218</span>
<span id="L219" rel="#L219">219</span>
<span id="L220" rel="#L220">220</span>
<span id="L221" rel="#L221">221</span>
<span id="L222" rel="#L222">222</span>
<span id="L223" rel="#L223">223</span>
<span id="L224" rel="#L224">224</span>
<span id="L225" rel="#L225">225</span>
<span id="L226" rel="#L226">226</span>
<span id="L227" rel="#L227">227</span>
<span id="L228" rel="#L228">228</span>
<span id="L229" rel="#L229">229</span>
<span id="L230" rel="#L230">230</span>
<span id="L231" rel="#L231">231</span>
<span id="L232" rel="#L232">232</span>
<span id="L233" rel="#L233">233</span>
<span id="L234" rel="#L234">234</span>
<span id="L235" rel="#L235">235</span>
<span id="L236" rel="#L236">236</span>
<span id="L237" rel="#L237">237</span>
<span id="L238" rel="#L238">238</span>
<span id="L239" rel="#L239">239</span>
<span id="L240" rel="#L240">240</span>
<span id="L241" rel="#L241">241</span>
<span id="L242" rel="#L242">242</span>
<span id="L243" rel="#L243">243</span>
<span id="L244" rel="#L244">244</span>
<span id="L245" rel="#L245">245</span>
<span id="L246" rel="#L246">246</span>
<span id="L247" rel="#L247">247</span>
<span id="L248" rel="#L248">248</span>
<span id="L249" rel="#L249">249</span>
<span id="L250" rel="#L250">250</span>
<span id="L251" rel="#L251">251</span>
<span id="L252" rel="#L252">252</span>
<span id="L253" rel="#L253">253</span>
<span id="L254" rel="#L254">254</span>
<span id="L255" rel="#L255">255</span>
<span id="L256" rel="#L256">256</span>
<span id="L257" rel="#L257">257</span>
<span id="L258" rel="#L258">258</span>
<span id="L259" rel="#L259">259</span>
<span id="L260" rel="#L260">260</span>
<span id="L261" rel="#L261">261</span>
<span id="L262" rel="#L262">262</span>
<span id="L263" rel="#L263">263</span>
<span id="L264" rel="#L264">264</span>
<span id="L265" rel="#L265">265</span>
<span id="L266" rel="#L266">266</span>
<span id="L267" rel="#L267">267</span>
<span id="L268" rel="#L268">268</span>
<span id="L269" rel="#L269">269</span>
<span id="L270" rel="#L270">270</span>
<span id="L271" rel="#L271">271</span>
<span id="L272" rel="#L272">272</span>
<span id="L273" rel="#L273">273</span>
<span id="L274" rel="#L274">274</span>
<span id="L275" rel="#L275">275</span>
<span id="L276" rel="#L276">276</span>
<span id="L277" rel="#L277">277</span>
<span id="L278" rel="#L278">278</span>
<span id="L279" rel="#L279">279</span>
<span id="L280" rel="#L280">280</span>
<span id="L281" rel="#L281">281</span>
<span id="L282" rel="#L282">282</span>
<span id="L283" rel="#L283">283</span>
<span id="L284" rel="#L284">284</span>
<span id="L285" rel="#L285">285</span>
<span id="L286" rel="#L286">286</span>
<span id="L287" rel="#L287">287</span>
<span id="L288" rel="#L288">288</span>
<span id="L289" rel="#L289">289</span>
<span id="L290" rel="#L290">290</span>
<span id="L291" rel="#L291">291</span>
<span id="L292" rel="#L292">292</span>
<span id="L293" rel="#L293">293</span>
<span id="L294" rel="#L294">294</span>
<span id="L295" rel="#L295">295</span>
<span id="L296" rel="#L296">296</span>
<span id="L297" rel="#L297">297</span>
<span id="L298" rel="#L298">298</span>
<span id="L299" rel="#L299">299</span>
<span id="L300" rel="#L300">300</span>
<span id="L301" rel="#L301">301</span>
<span id="L302" rel="#L302">302</span>
<span id="L303" rel="#L303">303</span>
<span id="L304" rel="#L304">304</span>
<span id="L305" rel="#L305">305</span>
<span id="L306" rel="#L306">306</span>
<span id="L307" rel="#L307">307</span>
<span id="L308" rel="#L308">308</span>
<span id="L309" rel="#L309">309</span>
<span id="L310" rel="#L310">310</span>
<span id="L311" rel="#L311">311</span>
<span id="L312" rel="#L312">312</span>
<span id="L313" rel="#L313">313</span>
<span id="L314" rel="#L314">314</span>
<span id="L315" rel="#L315">315</span>
<span id="L316" rel="#L316">316</span>
<span id="L317" rel="#L317">317</span>
<span id="L318" rel="#L318">318</span>
<span id="L319" rel="#L319">319</span>
<span id="L320" rel="#L320">320</span>
<span id="L321" rel="#L321">321</span>
<span id="L322" rel="#L322">322</span>
<span id="L323" rel="#L323">323</span>
<span id="L324" rel="#L324">324</span>
<span id="L325" rel="#L325">325</span>
<span id="L326" rel="#L326">326</span>
<span id="L327" rel="#L327">327</span>
<span id="L328" rel="#L328">328</span>
<span id="L329" rel="#L329">329</span>
<span id="L330" rel="#L330">330</span>
<span id="L331" rel="#L331">331</span>
<span id="L332" rel="#L332">332</span>
<span id="L333" rel="#L333">333</span>
<span id="L334" rel="#L334">334</span>
<span id="L335" rel="#L335">335</span>
<span id="L336" rel="#L336">336</span>
<span id="L337" rel="#L337">337</span>
<span id="L338" rel="#L338">338</span>
<span id="L339" rel="#L339">339</span>
<span id="L340" rel="#L340">340</span>
<span id="L341" rel="#L341">341</span>
<span id="L342" rel="#L342">342</span>
<span id="L343" rel="#L343">343</span>
<span id="L344" rel="#L344">344</span>
<span id="L345" rel="#L345">345</span>
<span id="L346" rel="#L346">346</span>
<span id="L347" rel="#L347">347</span>
<span id="L348" rel="#L348">348</span>
<span id="L349" rel="#L349">349</span>
<span id="L350" rel="#L350">350</span>
<span id="L351" rel="#L351">351</span>
<span id="L352" rel="#L352">352</span>
<span id="L353" rel="#L353">353</span>
<span id="L354" rel="#L354">354</span>
<span id="L355" rel="#L355">355</span>
<span id="L356" rel="#L356">356</span>
<span id="L357" rel="#L357">357</span>
<span id="L358" rel="#L358">358</span>
<span id="L359" rel="#L359">359</span>
<span id="L360" rel="#L360">360</span>
<span id="L361" rel="#L361">361</span>
<span id="L362" rel="#L362">362</span>
<span id="L363" rel="#L363">363</span>
<span id="L364" rel="#L364">364</span>
<span id="L365" rel="#L365">365</span>
<span id="L366" rel="#L366">366</span>
<span id="L367" rel="#L367">367</span>
<span id="L368" rel="#L368">368</span>
<span id="L369" rel="#L369">369</span>
<span id="L370" rel="#L370">370</span>
<span id="L371" rel="#L371">371</span>
<span id="L372" rel="#L372">372</span>
<span id="L373" rel="#L373">373</span>
<span id="L374" rel="#L374">374</span>
<span id="L375" rel="#L375">375</span>
<span id="L376" rel="#L376">376</span>
<span id="L377" rel="#L377">377</span>
<span id="L378" rel="#L378">378</span>
<span id="L379" rel="#L379">379</span>
<span id="L380" rel="#L380">380</span>
<span id="L381" rel="#L381">381</span>
<span id="L382" rel="#L382">382</span>

          </td>
          <td class="blob-line-code">
                  <div class="highlight"><pre><div class='line' id='LC1'><span class="cm">/*!</span></div><div class='line' id='LC2'><span class="cm"> * PayPalJSButtons</span></div><div class='line' id='LC3'><span class="cm"> * JavaScript integration for PayPal&#39;s payment buttons</span></div><div class='line' id='LC4'><span class="cm"> * @version 1.0.1 - 2013-05-07</span></div><div class='line' id='LC5'><span class="cm"> * @author Jeff Harrell &lt;https://github.com/jeffharrell/&gt;</span></div><div class='line' id='LC6'><span class="cm"> */</span></div><div class='line' id='LC7'><span class="k">if</span> <span class="p">(</span><span class="k">typeof</span> <span class="nx">PAYPAL</span> <span class="o">===</span> <span class="s1">&#39;undefined&#39;</span> <span class="o">||</span> <span class="o">!</span><span class="nx">PAYPAL</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC8'>	<span class="kd">var</span> <span class="nx">PAYPAL</span> <span class="o">=</span> <span class="p">{};</span></div><div class='line' id='LC9'><span class="p">}</span></div><div class='line' id='LC10'><br/></div><div class='line' id='LC11'><span class="nx">PAYPAL</span><span class="p">.</span><span class="nx">apps</span> <span class="o">=</span> <span class="nx">PAYPAL</span><span class="p">.</span><span class="nx">apps</span> <span class="o">||</span> <span class="p">{};</span></div><div class='line' id='LC12'><br/></div><div class='line' id='LC13'><br/></div><div class='line' id='LC14'><span class="p">(</span><span class="kd">function</span> <span class="p">()</span> <span class="p">{</span></div><div class='line' id='LC15'><br/></div><div class='line' id='LC16'>	<span class="s1">&#39;use strict&#39;</span><span class="p">;</span></div><div class='line' id='LC17'><br/></div><div class='line' id='LC18'><br/></div><div class='line' id='LC19'>	<span class="kd">var</span> <span class="nx">app</span> <span class="o">=</span> <span class="p">{},</span></div><div class='line' id='LC20'>		<span class="nx">paypalURL</span> <span class="o">=</span> <span class="s1">&#39;https://{env}.paypal.com/cgi-bin/webscr&#39;</span><span class="p">,</span></div><div class='line' id='LC21'>		<span class="nx">qrCodeURL</span> <span class="o">=</span> <span class="s1">&#39;https://{env}.paypal.com/webapps/ppint/qrcode?data={url}&amp;pattern={pattern}&amp;height={size}&#39;</span><span class="p">,</span></div><div class='line' id='LC22'>		<span class="nx">bnCode</span> <span class="o">=</span> <span class="s1">&#39;JavaScriptButton_{type}&#39;</span><span class="p">,</span></div><div class='line' id='LC23'>		<span class="nx">prettyParams</span> <span class="o">=</span> <span class="p">{</span></div><div class='line' id='LC24'>			<span class="nx">name</span><span class="o">:</span> <span class="s1">&#39;item_name&#39;</span><span class="p">,</span></div><div class='line' id='LC25'>			<span class="nx">number</span><span class="o">:</span> <span class="s1">&#39;item_number&#39;</span><span class="p">,</span></div><div class='line' id='LC26'>			<span class="nx">locale</span><span class="o">:</span> <span class="s1">&#39;lc&#39;</span><span class="p">,</span></div><div class='line' id='LC27'>			<span class="nx">currency</span><span class="o">:</span> <span class="s1">&#39;currency_code&#39;</span><span class="p">,</span></div><div class='line' id='LC28'>			<span class="nx">recurrence</span><span class="o">:</span> <span class="s1">&#39;p3&#39;</span><span class="p">,</span></div><div class='line' id='LC29'>			<span class="nx">period</span><span class="o">:</span> <span class="s1">&#39;t3&#39;</span><span class="p">,</span></div><div class='line' id='LC30'>			<span class="nx">callback</span><span class="o">:</span> <span class="s1">&#39;notify_url&#39;</span></div><div class='line' id='LC31'>		<span class="p">},</span></div><div class='line' id='LC32'>		<span class="nx">locales</span> <span class="o">=</span> <span class="p">{</span></div><div class='line' id='LC33'>			<span class="nx">da_DK</span><span class="o">:</span> <span class="p">{</span> <span class="nx">buynow</span><span class="o">:</span> <span class="s1">&#39;Køb nu&#39;</span><span class="p">,</span> <span class="nx">cart</span><span class="o">:</span> <span class="s1">&#39;Læg i indkøbsvogn&#39;</span><span class="p">,</span> <span class="nx">donate</span><span class="o">:</span> <span class="s1">&#39;Doner&#39;</span><span class="p">,</span> <span class="nx">subscribe</span><span class="o">:</span> <span class="s1">&#39;Abonner&#39;</span><span class="p">,</span> <span class="nx">item_name</span><span class="o">:</span> <span class="s1">&#39;Vare&#39;</span><span class="p">,</span> <span class="nx">number</span><span class="o">:</span> <span class="s1">&#39;Nummer&#39;</span><span class="p">,</span> <span class="nx">amount</span><span class="o">:</span> <span class="s1">&#39;Pris&#39;</span><span class="p">,</span> <span class="nx">quantity</span><span class="o">:</span> <span class="s1">&#39;Antal&#39;</span> <span class="p">},</span></div><div class='line' id='LC34'>			<span class="nx">de_DE</span><span class="o">:</span> <span class="p">{</span> <span class="nx">buynow</span><span class="o">:</span> <span class="s1">&#39;Jetzt kaufen&#39;</span><span class="p">,</span> <span class="nx">cart</span><span class="o">:</span> <span class="s1">&#39;In den Warenkorb&#39;</span><span class="p">,</span> <span class="nx">donate</span><span class="o">:</span> <span class="s1">&#39;Spenden&#39;</span><span class="p">,</span> <span class="nx">subscribe</span><span class="o">:</span> <span class="s1">&#39;Abonnieren&#39;</span><span class="p">,</span> <span class="nx">item_name</span><span class="o">:</span> <span class="s1">&#39;Artikel&#39;</span><span class="p">,</span> <span class="nx">number</span><span class="o">:</span> <span class="s1">&#39;Nummer&#39;</span><span class="p">,</span> <span class="nx">amount</span><span class="o">:</span> <span class="s1">&#39;Betrag&#39;</span><span class="p">,</span> <span class="nx">quantity</span><span class="o">:</span> <span class="s1">&#39;Menge&#39;</span> <span class="p">},</span></div><div class='line' id='LC35'>			<span class="nx">en_AU</span><span class="o">:</span> <span class="p">{</span> <span class="nx">buynow</span><span class="o">:</span> <span class="s1">&#39;Buy Now&#39;</span><span class="p">,</span> <span class="nx">cart</span><span class="o">:</span> <span class="s1">&#39;Add to Cart&#39;</span><span class="p">,</span> <span class="nx">donate</span><span class="o">:</span> <span class="s1">&#39;Donate&#39;</span><span class="p">,</span> <span class="nx">subscribe</span><span class="o">:</span> <span class="s1">&#39;Subscribe&#39;</span><span class="p">,</span> <span class="nx">item_name</span><span class="o">:</span> <span class="s1">&#39;Item&#39;</span><span class="p">,</span> <span class="nx">number</span><span class="o">:</span> <span class="s1">&#39;Number&#39;</span><span class="p">,</span> <span class="nx">amount</span><span class="o">:</span> <span class="s1">&#39;Amount&#39;</span><span class="p">,</span> <span class="nx">quantity</span><span class="o">:</span> <span class="s1">&#39;Quantity&#39;</span> <span class="p">},</span></div><div class='line' id='LC36'>			<span class="nx">en_GB</span><span class="o">:</span> <span class="p">{</span> <span class="nx">buynow</span><span class="o">:</span> <span class="s1">&#39;Buy Now&#39;</span><span class="p">,</span> <span class="nx">cart</span><span class="o">:</span> <span class="s1">&#39;Add to Cart&#39;</span><span class="p">,</span> <span class="nx">donate</span><span class="o">:</span> <span class="s1">&#39;Donate&#39;</span><span class="p">,</span> <span class="nx">subscribe</span><span class="o">:</span> <span class="s1">&#39;Subscribe&#39;</span><span class="p">,</span> <span class="nx">item_name</span><span class="o">:</span> <span class="s1">&#39;Item&#39;</span><span class="p">,</span> <span class="nx">number</span><span class="o">:</span> <span class="s1">&#39;Number&#39;</span><span class="p">,</span> <span class="nx">amount</span><span class="o">:</span> <span class="s1">&#39;Amount&#39;</span><span class="p">,</span> <span class="nx">quantity</span><span class="o">:</span> <span class="s1">&#39;Quantity&#39;</span> <span class="p">},</span></div><div class='line' id='LC37'>			<span class="nx">en_US</span><span class="o">:</span> <span class="p">{</span> <span class="nx">buynow</span><span class="o">:</span> <span class="s1">&#39;Buy Now&#39;</span><span class="p">,</span> <span class="nx">cart</span><span class="o">:</span> <span class="s1">&#39;Add to Cart&#39;</span><span class="p">,</span> <span class="nx">donate</span><span class="o">:</span> <span class="s1">&#39;Donate&#39;</span><span class="p">,</span> <span class="nx">subscribe</span><span class="o">:</span> <span class="s1">&#39;Subscribe&#39;</span><span class="p">,</span> <span class="nx">item_name</span><span class="o">:</span> <span class="s1">&#39;Item&#39;</span><span class="p">,</span> <span class="nx">number</span><span class="o">:</span> <span class="s1">&#39;Number&#39;</span><span class="p">,</span> <span class="nx">amount</span><span class="o">:</span> <span class="s1">&#39;Amount&#39;</span><span class="p">,</span> <span class="nx">quantity</span><span class="o">:</span> <span class="s1">&#39;Quantity&#39;</span> <span class="p">},</span></div><div class='line' id='LC38'>			<span class="nx">es_ES</span><span class="o">:</span> <span class="p">{</span> <span class="nx">buynow</span><span class="o">:</span> <span class="s1">&#39;Comprar ahora&#39;</span><span class="p">,</span> <span class="nx">cart</span><span class="o">:</span> <span class="s1">&#39;Añadir al carro&#39;</span><span class="p">,</span> <span class="nx">donate</span><span class="o">:</span> <span class="s1">&#39;Donar&#39;</span><span class="p">,</span> <span class="nx">subscribe</span><span class="o">:</span> <span class="s1">&#39;Suscribirse&#39;</span><span class="p">,</span> <span class="nx">item_name</span><span class="o">:</span> <span class="s1">&#39;Artículo&#39;</span><span class="p">,</span> <span class="nx">number</span><span class="o">:</span> <span class="s1">&#39;Número&#39;</span><span class="p">,</span> <span class="nx">amount</span><span class="o">:</span> <span class="s1">&#39;Importe&#39;</span><span class="p">,</span> <span class="nx">quantity</span><span class="o">:</span> <span class="s1">&#39;Cantidad&#39;</span> <span class="p">},</span></div><div class='line' id='LC39'>			<span class="nx">es_XC</span><span class="o">:</span> <span class="p">{</span> <span class="nx">buynow</span><span class="o">:</span> <span class="s1">&#39;Comprar ahora&#39;</span><span class="p">,</span> <span class="nx">cart</span><span class="o">:</span> <span class="s1">&#39;Añadir al carrito&#39;</span><span class="p">,</span> <span class="nx">donate</span><span class="o">:</span> <span class="s1">&#39;Donar&#39;</span><span class="p">,</span> <span class="nx">subscribe</span><span class="o">:</span> <span class="s1">&#39;Suscribirse&#39;</span><span class="p">,</span> <span class="nx">item_name</span><span class="o">:</span> <span class="s1">&#39;Artículo&#39;</span><span class="p">,</span> <span class="nx">number</span><span class="o">:</span> <span class="s1">&#39;Número&#39;</span><span class="p">,</span> <span class="nx">amount</span><span class="o">:</span> <span class="s1">&#39;Importe&#39;</span><span class="p">,</span> <span class="nx">quantity</span><span class="o">:</span> <span class="s1">&#39;Cantidad&#39;</span> <span class="p">},</span></div><div class='line' id='LC40'>			<span class="nx">fr_CA</span><span class="o">:</span> <span class="p">{</span> <span class="nx">buynow</span><span class="o">:</span> <span class="s1">&#39;Acheter&#39;</span><span class="p">,</span> <span class="nx">cart</span><span class="o">:</span> <span class="s1">&#39;Ajouter au panier&#39;</span><span class="p">,</span> <span class="nx">donate</span><span class="o">:</span> <span class="s1">&#39;Faire un don&#39;</span><span class="p">,</span> <span class="nx">subscribe</span><span class="o">:</span> <span class="s1">&#39;Souscrire&#39;</span><span class="p">,</span> <span class="nx">item_name</span><span class="o">:</span> <span class="s1">&#39;Objet&#39;</span><span class="p">,</span> <span class="nx">number</span><span class="o">:</span> <span class="s1">&#39;Numéro&#39;</span><span class="p">,</span> <span class="nx">amount</span><span class="o">:</span> <span class="s1">&#39;Montant&#39;</span><span class="p">,</span> <span class="nx">quantity</span><span class="o">:</span> <span class="s1">&#39;Quantité&#39;</span> <span class="p">},</span></div><div class='line' id='LC41'>			<span class="nx">fr_FR</span><span class="o">:</span> <span class="p">{</span> <span class="nx">buynow</span><span class="o">:</span> <span class="s1">&#39;Acheter&#39;</span><span class="p">,</span> <span class="nx">cart</span><span class="o">:</span> <span class="s1">&#39;Ajouter au panier&#39;</span><span class="p">,</span> <span class="nx">donate</span><span class="o">:</span> <span class="s1">&#39;Faire un don&#39;</span><span class="p">,</span> <span class="nx">subscribe</span><span class="o">:</span> <span class="s1">&#39;Souscrire&#39;</span><span class="p">,</span> <span class="nx">item_name</span><span class="o">:</span> <span class="s1">&#39;Objet&#39;</span><span class="p">,</span> <span class="nx">number</span><span class="o">:</span> <span class="s1">&#39;Numéro&#39;</span><span class="p">,</span> <span class="nx">amount</span><span class="o">:</span> <span class="s1">&#39;Montant&#39;</span><span class="p">,</span> <span class="nx">quantity</span><span class="o">:</span> <span class="s1">&#39;Quantité&#39;</span> <span class="p">},</span></div><div class='line' id='LC42'>			<span class="nx">fr_XC</span><span class="o">:</span> <span class="p">{</span> <span class="nx">buynow</span><span class="o">:</span> <span class="s1">&#39;Acheter&#39;</span><span class="p">,</span> <span class="nx">cart</span><span class="o">:</span> <span class="s1">&#39;Ajouter au panier&#39;</span><span class="p">,</span> <span class="nx">donate</span><span class="o">:</span> <span class="s1">&#39;Faire un don&#39;</span><span class="p">,</span> <span class="nx">subscribe</span><span class="o">:</span> <span class="s1">&#39;Souscrire&#39;</span><span class="p">,</span> <span class="nx">item_name</span><span class="o">:</span> <span class="s1">&#39;Objet&#39;</span><span class="p">,</span> <span class="nx">number</span><span class="o">:</span> <span class="s1">&#39;Numéro&#39;</span><span class="p">,</span> <span class="nx">amount</span><span class="o">:</span> <span class="s1">&#39;Montant&#39;</span><span class="p">,</span> <span class="nx">quantity</span><span class="o">:</span> <span class="s1">&#39;Quantité&#39;</span> <span class="p">},</span></div><div class='line' id='LC43'>			<span class="nx">he_IL</span><span class="o">:</span> <span class="p">{</span> <span class="nx">buynow</span><span class="o">:</span> <span class="s1">&#39;וישכע הנק&#39;</span><span class="p">,</span> <span class="nx">cart</span><span class="o">:</span> <span class="s1">&#39;תוינקה לסל ףסוה&#39;</span><span class="p">,</span> <span class="nx">donate</span><span class="o">:</span> <span class="s1">&#39;םורת&#39;</span><span class="p">,</span> <span class="nx">subscribe</span><span class="o">:</span> <span class="s1">&#39;יונמכ ףרטצה&#39;</span><span class="p">,</span> <span class="nx">item_name</span><span class="o">:</span> <span class="s1">&#39;טירפ&#39;</span><span class="p">,</span> <span class="nx">number</span><span class="o">:</span> <span class="s1">&#39;רפסמ&#39;</span><span class="p">,</span> <span class="nx">amount</span><span class="o">:</span> <span class="s1">&#39;םוכס&#39;</span><span class="p">,</span> <span class="nx">quantity</span><span class="o">:</span> <span class="s1">&#39;מותכ&#39;</span> <span class="p">},</span></div><div class='line' id='LC44'>			<span class="nx">id_ID</span><span class="o">:</span> <span class="p">{</span> <span class="nx">buynow</span><span class="o">:</span> <span class="s1">&#39;Beli Sekarang&#39;</span><span class="p">,</span> <span class="nx">cart</span><span class="o">:</span> <span class="s1">&#39;Tambah ke Keranjang&#39;</span><span class="p">,</span> <span class="nx">donate</span><span class="o">:</span> <span class="s1">&#39;Donasikan&#39;</span><span class="p">,</span> <span class="nx">subscribe</span><span class="o">:</span> <span class="s1">&#39;Berlangganan&#39;</span><span class="p">,</span> <span class="nx">item_name</span><span class="o">:</span> <span class="s1">&#39;Barang&#39;</span><span class="p">,</span> <span class="nx">number</span><span class="o">:</span> <span class="s1">&#39;Nomor&#39;</span><span class="p">,</span> <span class="nx">amount</span><span class="o">:</span> <span class="s1">&#39;Harga&#39;</span><span class="p">,</span> <span class="nx">quantity</span><span class="o">:</span> <span class="s1">&#39;Kuantitas&#39;</span> <span class="p">},</span></div><div class='line' id='LC45'>			<span class="nx">it_IT</span><span class="o">:</span> <span class="p">{</span> <span class="nx">buynow</span><span class="o">:</span> <span class="s1">&#39;Paga adesso&#39;</span><span class="p">,</span> <span class="nx">cart</span><span class="o">:</span> <span class="s1">&#39;Aggiungi al carrello&#39;</span><span class="p">,</span> <span class="nx">donate</span><span class="o">:</span> <span class="s1">&#39;Donazione&#39;</span><span class="p">,</span> <span class="nx">subscribe</span><span class="o">:</span> <span class="s1">&#39;Iscriviti&#39;</span><span class="p">,</span> <span class="nx">item_name</span><span class="o">:</span> <span class="s1">&#39;Oggetto&#39;</span><span class="p">,</span> <span class="nx">number</span><span class="o">:</span> <span class="s1">&#39;Numero&#39;</span><span class="p">,</span> <span class="nx">amount</span><span class="o">:</span> <span class="s1">&#39;Importo&#39;</span><span class="p">,</span> <span class="nx">quantity</span><span class="o">:</span> <span class="s1">&#39;Quantità&#39;</span> <span class="p">},</span></div><div class='line' id='LC46'>			<span class="nx">ja_JP</span><span class="o">:</span> <span class="p">{</span> <span class="nx">buynow</span><span class="o">:</span> <span class="s1">&#39;今すぐ購入&#39;</span><span class="p">,</span> <span class="nx">cart</span><span class="o">:</span> <span class="s1">&#39;カートに追加&#39;</span><span class="p">,</span> <span class="nx">donate</span><span class="o">:</span> <span class="s1">&#39;寄付&#39;</span><span class="p">,</span> <span class="nx">subscribe</span><span class="o">:</span> <span class="s1">&#39;購読&#39;</span><span class="p">,</span> <span class="nx">item_name</span><span class="o">:</span> <span class="s1">&#39;商品&#39;</span><span class="p">,</span> <span class="nx">number</span><span class="o">:</span> <span class="s1">&#39;番号&#39;</span><span class="p">,</span> <span class="nx">amount</span><span class="o">:</span> <span class="s1">&#39;価格&#39;</span><span class="p">,</span> <span class="nx">quantity</span><span class="o">:</span> <span class="s1">&#39;数量&#39;</span> <span class="p">},</span></div><div class='line' id='LC47'>			<span class="nx">nl_NL</span><span class="o">:</span> <span class="p">{</span> <span class="nx">buynow</span><span class="o">:</span> <span class="s1">&#39;Nu kopen&#39;</span><span class="p">,</span> <span class="nx">cart</span><span class="o">:</span> <span class="s1">&#39;Aan winkelwagentje toevoegen&#39;</span><span class="p">,</span> <span class="nx">donate</span><span class="o">:</span> <span class="s1">&#39;Doneren&#39;</span><span class="p">,</span> <span class="nx">subscribe</span><span class="o">:</span> <span class="s1">&#39;Abonneren&#39;</span><span class="p">,</span> <span class="nx">item_name</span><span class="o">:</span> <span class="s1">&#39;Item&#39;</span><span class="p">,</span> <span class="nx">number</span><span class="o">:</span> <span class="s1">&#39;Nummer&#39;</span><span class="p">,</span> <span class="nx">amount</span><span class="o">:</span> <span class="s1">&#39;Bedrag&#39;</span><span class="p">,</span> <span class="nx">quantity</span><span class="o">:</span> <span class="s1">&#39;Hoeveelheid&#39;</span> <span class="p">},</span></div><div class='line' id='LC48'>			<span class="nx">no_NO</span><span class="o">:</span> <span class="p">{</span> <span class="nx">buynow</span><span class="o">:</span> <span class="s1">&#39;Kjøp nå&#39;</span><span class="p">,</span> <span class="nx">cart</span><span class="o">:</span> <span class="s1">&#39;Legg til i kurv&#39;</span><span class="p">,</span> <span class="nx">donate</span><span class="o">:</span> <span class="s1">&#39;Doner&#39;</span><span class="p">,</span> <span class="nx">subscribe</span><span class="o">:</span> <span class="s1">&#39;Abonner&#39;</span><span class="p">,</span> <span class="nx">item_name</span><span class="o">:</span> <span class="s1">&#39;Vare&#39;</span><span class="p">,</span> <span class="nx">number</span><span class="o">:</span> <span class="s1">&#39;Nummer&#39;</span><span class="p">,</span> <span class="nx">amount</span><span class="o">:</span> <span class="s1">&#39;Beløp&#39;</span><span class="p">,</span> <span class="nx">quantity</span><span class="o">:</span> <span class="s1">&#39;Antall&#39;</span> <span class="p">},</span></div><div class='line' id='LC49'>			<span class="nx">pl_PL</span><span class="o">:</span> <span class="p">{</span> <span class="nx">buynow</span><span class="o">:</span> <span class="s1">&#39;Kup teraz&#39;</span><span class="p">,</span> <span class="nx">cart</span><span class="o">:</span> <span class="s1">&#39;Dodaj do koszyka&#39;</span><span class="p">,</span> <span class="nx">donate</span><span class="o">:</span> <span class="s1">&#39;Przekaż darowiznę&#39;</span><span class="p">,</span> <span class="nx">subscribe</span><span class="o">:</span> <span class="s1">&#39;Subskrybuj&#39;</span><span class="p">,</span> <span class="nx">item_name</span><span class="o">:</span> <span class="s1">&#39;Przedmiot&#39;</span><span class="p">,</span> <span class="nx">number</span><span class="o">:</span> <span class="s1">&#39;Numer&#39;</span><span class="p">,</span> <span class="nx">amount</span><span class="o">:</span> <span class="s1">&#39;Kwota&#39;</span><span class="p">,</span> <span class="nx">quantity</span><span class="o">:</span> <span class="s1">&#39;Ilość&#39;</span> <span class="p">},</span></div><div class='line' id='LC50'>			<span class="nx">pt_BR</span><span class="o">:</span> <span class="p">{</span> <span class="nx">buynow</span><span class="o">:</span> <span class="s1">&#39;Comprar agora&#39;</span><span class="p">,</span> <span class="nx">cart</span><span class="o">:</span> <span class="s1">&#39;Adicionar ao carrinho&#39;</span><span class="p">,</span> <span class="nx">donate</span><span class="o">:</span> <span class="s1">&#39;Doar&#39;</span><span class="p">,</span> <span class="nx">subscribe</span><span class="o">:</span> <span class="s1">&#39;Assinar&#39;</span><span class="p">,</span> <span class="nx">item_name</span><span class="o">:</span> <span class="s1">&#39;Produto&#39;</span><span class="p">,</span> <span class="nx">number</span><span class="o">:</span> <span class="s1">&#39;Número&#39;</span><span class="p">,</span> <span class="nx">amount</span><span class="o">:</span> <span class="s1">&#39;Valor&#39;</span><span class="p">,</span> <span class="nx">quantity</span><span class="o">:</span> <span class="s1">&#39;Quantidade&#39;</span> <span class="p">},</span></div><div class='line' id='LC51'>			<span class="nx">ru_RU</span><span class="o">:</span> <span class="p">{</span> <span class="nx">buynow</span><span class="o">:</span> <span class="s1">&#39;Купить сейчас&#39;</span><span class="p">,</span> <span class="nx">cart</span><span class="o">:</span> <span class="s1">&#39;Добавить в корзину&#39;</span><span class="p">,</span> <span class="nx">donate</span><span class="o">:</span> <span class="s1">&#39;Пожертвовать&#39;</span><span class="p">,</span> <span class="nx">subscribe</span><span class="o">:</span> <span class="s1">&#39;Подписаться&#39;</span><span class="p">,</span> <span class="nx">item_name</span><span class="o">:</span> <span class="s1">&#39;Товар&#39;</span><span class="p">,</span> <span class="nx">number</span><span class="o">:</span> <span class="s1">&#39;Номер&#39;</span><span class="p">,</span> <span class="nx">amount</span><span class="o">:</span> <span class="s1">&#39;Сумма&#39;</span><span class="p">,</span> <span class="nx">quantity</span><span class="o">:</span> <span class="s1">&#39;Количество&#39;</span> <span class="p">},</span></div><div class='line' id='LC52'>			<span class="nx">sv_SE</span><span class="o">:</span> <span class="p">{</span> <span class="nx">buynow</span><span class="o">:</span> <span class="s1">&#39;Köp nu&#39;</span><span class="p">,</span> <span class="nx">cart</span><span class="o">:</span> <span class="s1">&#39;Lägg till i kundvagn&#39;</span><span class="p">,</span> <span class="nx">donate</span><span class="o">:</span> <span class="s1">&#39;Donera&#39;</span><span class="p">,</span> <span class="nx">subscribe</span><span class="o">:</span> <span class="s1">&#39;Abonnera&#39;</span><span class="p">,</span> <span class="nx">item_name</span><span class="o">:</span> <span class="s1">&#39;Objekt&#39;</span><span class="p">,</span> <span class="nx">number</span><span class="o">:</span> <span class="s1">&#39;Nummer&#39;</span><span class="p">,</span> <span class="nx">amount</span><span class="o">:</span> <span class="s1">&#39;Belopp&#39;</span><span class="p">,</span> <span class="nx">quantity</span><span class="o">:</span> <span class="s1">&#39;Antal&#39;</span> <span class="p">},</span></div><div class='line' id='LC53'>			<span class="nx">th_TH</span><span class="o">:</span> <span class="p">{</span> <span class="nx">buynow</span><span class="o">:</span> <span class="s1">&#39;ซื้อทันที&#39;</span><span class="p">,</span> <span class="nx">cart</span><span class="o">:</span> <span class="s1">&#39;เพิ่มลงตะกร้า&#39;</span><span class="p">,</span> <span class="nx">donate</span><span class="o">:</span> <span class="s1">&#39;บริจาค&#39;</span><span class="p">,</span> <span class="nx">subscribe</span><span class="o">:</span> <span class="s1">&#39;บอกรับสมาชิก&#39;</span><span class="p">,</span> <span class="nx">item_name</span><span class="o">:</span> <span class="s1">&#39;ชื่อสินค้า&#39;</span><span class="p">,</span> <span class="nx">number</span><span class="o">:</span> <span class="s1">&#39;รหัสสินค้า&#39;</span><span class="p">,</span> <span class="nx">amount</span><span class="o">:</span> <span class="s1">&#39;ราคา&#39;</span><span class="p">,</span> <span class="nx">quantity</span><span class="o">:</span> <span class="s1">&#39;จำนวน&#39;</span> <span class="p">},</span></div><div class='line' id='LC54'>			<span class="nx">tr_TR</span><span class="o">:</span> <span class="p">{</span> <span class="nx">buynow</span><span class="o">:</span> <span class="s1">&#39;Hemen Alın&#39;</span><span class="p">,</span> <span class="nx">cart</span><span class="o">:</span> <span class="s1">&#39;Sepete Ekleyin&#39;</span><span class="p">,</span> <span class="nx">donate</span><span class="o">:</span> <span class="s1">&#39;Bağış Yapın&#39;</span><span class="p">,</span> <span class="nx">subscribe</span><span class="o">:</span> <span class="s1">&#39;Abone Olun&#39;</span><span class="p">,</span> <span class="nx">item_name</span><span class="o">:</span> <span class="s1">&#39;Ürün&#39;</span><span class="p">,</span> <span class="nx">number</span><span class="o">:</span> <span class="s1">&#39;Numara&#39;</span><span class="p">,</span> <span class="nx">amount</span><span class="o">:</span> <span class="s1">&#39;Tutar&#39;</span><span class="p">,</span> <span class="nx">quantity</span><span class="o">:</span> <span class="s1">&#39;Miktar&#39;</span> <span class="p">},</span></div><div class='line' id='LC55'>			<span class="nx">zh_CN</span><span class="o">:</span> <span class="p">{</span> <span class="nx">buynow</span><span class="o">:</span> <span class="s1">&#39;立即购买&#39;</span><span class="p">,</span> <span class="nx">cart</span><span class="o">:</span> <span class="s1">&#39;添加到购物车&#39;</span><span class="p">,</span> <span class="nx">donate</span><span class="o">:</span> <span class="s1">&#39;捐赠&#39;</span><span class="p">,</span> <span class="nx">subscribe</span><span class="o">:</span> <span class="s1">&#39;租用&#39;</span><span class="p">,</span> <span class="nx">item_name</span><span class="o">:</span> <span class="s1">&#39;物品&#39;</span><span class="p">,</span> <span class="nx">number</span><span class="o">:</span> <span class="s1">&#39;编号&#39;</span><span class="p">,</span> <span class="nx">amount</span><span class="o">:</span> <span class="s1">&#39;金额&#39;</span><span class="p">,</span> <span class="nx">quantity</span><span class="o">:</span> <span class="s1">&#39;数量&#39;</span> <span class="p">},</span></div><div class='line' id='LC56'>			<span class="nx">zh_HK</span><span class="o">:</span> <span class="p">{</span> <span class="nx">buynow</span><span class="o">:</span> <span class="s1">&#39;立即買&#39;</span><span class="p">,</span> <span class="nx">cart</span><span class="o">:</span> <span class="s1">&#39;加入購物車&#39;</span><span class="p">,</span> <span class="nx">donate</span><span class="o">:</span> <span class="s1">&#39;捐款&#39;</span><span class="p">,</span> <span class="nx">subscribe</span><span class="o">:</span> <span class="s1">&#39;訂用&#39;</span><span class="p">,</span> <span class="nx">item_name</span><span class="o">:</span> <span class="s1">&#39;項目&#39;</span><span class="p">,</span> <span class="nx">number</span><span class="o">:</span> <span class="s1">&#39;號碼&#39;</span><span class="p">,</span> <span class="nx">amount</span><span class="o">:</span> <span class="s1">&#39;金額&#39;</span><span class="p">,</span> <span class="nx">quantity</span><span class="o">:</span> <span class="s1">&#39;數量&#39;</span> <span class="p">},</span></div><div class='line' id='LC57'>			<span class="nx">zh_TW</span><span class="o">:</span> <span class="p">{</span> <span class="nx">buynow</span><span class="o">:</span> <span class="s1">&#39;立即購&#39;</span><span class="p">,</span> <span class="nx">cart</span><span class="o">:</span> <span class="s1">&#39;加到購物車&#39;</span><span class="p">,</span> <span class="nx">donate</span><span class="o">:</span> <span class="s1">&#39;捐款&#39;</span><span class="p">,</span> <span class="nx">subscribe</span><span class="o">:</span> <span class="s1">&#39;訂閱&#39;</span><span class="p">,</span> <span class="nx">item_name</span><span class="o">:</span> <span class="s1">&#39;商品&#39;</span><span class="p">,</span> <span class="nx">number</span><span class="o">:</span> <span class="s1">&#39;商品編號&#39;</span><span class="p">,</span> <span class="nx">amount</span><span class="o">:</span> <span class="s1">&#39;單價&#39;</span><span class="p">,</span> <span class="nx">quantity</span><span class="o">:</span> <span class="s1">&#39;數量&#39;</span> <span class="p">},</span></div><div class='line' id='LC58'>			<span class="nx">zh_XC</span><span class="o">:</span> <span class="p">{</span> <span class="nx">buynow</span><span class="o">:</span> <span class="s1">&#39;立即购买&#39;</span><span class="p">,</span> <span class="nx">cart</span><span class="o">:</span> <span class="s1">&#39;添加到购物车&#39;</span><span class="p">,</span> <span class="nx">donate</span><span class="o">:</span> <span class="s1">&#39;捐赠&#39;</span><span class="p">,</span> <span class="nx">subscribe</span><span class="o">:</span> <span class="s1">&#39;租用&#39;</span><span class="p">,</span> <span class="nx">item_name</span><span class="o">:</span> <span class="s1">&#39;物品&#39;</span><span class="p">,</span> <span class="nx">number</span><span class="o">:</span> <span class="s1">&#39;编号&#39;</span><span class="p">,</span> <span class="nx">amount</span><span class="o">:</span> <span class="s1">&#39;金额&#39;</span><span class="p">,</span> <span class="nx">quantity</span><span class="o">:</span> <span class="s1">&#39;数量&#39;</span> <span class="p">}</span></div><div class='line' id='LC59'>		<span class="p">};</span></div><div class='line' id='LC60'><br/></div><div class='line' id='LC61'>	<span class="k">if</span> <span class="p">(</span><span class="o">!</span><span class="nx">PAYPAL</span><span class="p">.</span><span class="nx">apps</span><span class="p">.</span><span class="nx">ButtonFactory</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC62'><br/></div><div class='line' id='LC63'>		<span class="cm">/**</span></div><div class='line' id='LC64'><span class="cm">		 * Initial config for the app. These values can be overridden by the page.</span></div><div class='line' id='LC65'><span class="cm">		 */</span></div><div class='line' id='LC66'>		<span class="nx">app</span><span class="p">.</span><span class="nx">config</span> <span class="o">=</span> <span class="p">{</span></div><div class='line' id='LC67'>			<span class="nx">labels</span><span class="o">:</span> <span class="p">{}</span></div><div class='line' id='LC68'>		<span class="p">};</span></div><div class='line' id='LC69'><br/></div><div class='line' id='LC70'>		<span class="cm">/**</span></div><div class='line' id='LC71'><span class="cm">		 * A count of each type of button on the page</span></div><div class='line' id='LC72'><span class="cm">		 */</span></div><div class='line' id='LC73'>		<span class="nx">app</span><span class="p">.</span><span class="nx">buttons</span> <span class="o">=</span> <span class="p">{</span></div><div class='line' id='LC74'>			<span class="nx">buynow</span><span class="o">:</span> <span class="mi">0</span><span class="p">,</span></div><div class='line' id='LC75'>			<span class="nx">cart</span><span class="o">:</span> <span class="mi">0</span><span class="p">,</span></div><div class='line' id='LC76'>			<span class="nx">donate</span><span class="o">:</span> <span class="mi">0</span><span class="p">,</span></div><div class='line' id='LC77'>			<span class="nx">qr</span><span class="o">:</span> <span class="mi">0</span><span class="p">,</span></div><div class='line' id='LC78'>			<span class="nx">subscribe</span><span class="o">:</span> <span class="mi">0</span></div><div class='line' id='LC79'>		<span class="p">};</span></div><div class='line' id='LC80'><br/></div><div class='line' id='LC81'>		<span class="cm">/**</span></div><div class='line' id='LC82'><span class="cm">		 * Renders a button in place of the given element</span></div><div class='line' id='LC83'><span class="cm">		 *</span></div><div class='line' id='LC84'><span class="cm">		 * @param business {Object} The ID or email address of the merchant to create the button for</span></div><div class='line' id='LC85'><span class="cm">		 * @param raw {Object} An object of key/value data to set as button params</span></div><div class='line' id='LC86'><span class="cm">		 * @param type (String) The type of the button to render</span></div><div class='line' id='LC87'><span class="cm">		 * @param parent {HTMLElement} The element to add the button to (Optional)</span></div><div class='line' id='LC88'><span class="cm">		 * @return {HTMLElement}</span></div><div class='line' id='LC89'><span class="cm">		 */</span></div><div class='line' id='LC90'>		<span class="nx">app</span><span class="p">.</span><span class="nx">create</span> <span class="o">=</span> <span class="kd">function</span> <span class="p">(</span><span class="nx">business</span><span class="p">,</span> <span class="nx">raw</span><span class="p">,</span> <span class="nx">type</span><span class="p">,</span> <span class="nx">parent</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC91'>			<span class="kd">var</span> <span class="nx">data</span> <span class="o">=</span> <span class="k">new</span> <span class="nx">DataStore</span><span class="p">(),</span> <span class="nx">button</span><span class="p">,</span> <span class="nx">key</span><span class="p">,</span> <span class="nx">env</span><span class="p">;</span></div><div class='line' id='LC92'><br/></div><div class='line' id='LC93'>			<span class="k">if</span> <span class="p">(</span><span class="o">!</span><span class="nx">business</span><span class="p">)</span> <span class="p">{</span> <span class="k">return</span> <span class="kc">false</span><span class="p">;</span> <span class="p">}</span></div><div class='line' id='LC94'><br/></div><div class='line' id='LC95'>			<span class="c1">// Normalize the data&#39;s keys and add to a data store</span></div><div class='line' id='LC96'>			<span class="k">for</span> <span class="p">(</span><span class="nx">key</span> <span class="k">in</span> <span class="nx">raw</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC97'>				<span class="nx">data</span><span class="p">.</span><span class="nx">add</span><span class="p">(</span><span class="nx">prettyParams</span><span class="p">[</span><span class="nx">key</span><span class="p">]</span> <span class="o">||</span> <span class="nx">key</span><span class="p">,</span> <span class="nx">raw</span><span class="p">[</span><span class="nx">key</span><span class="p">].</span><span class="nx">value</span><span class="p">,</span> <span class="nx">raw</span><span class="p">[</span><span class="nx">key</span><span class="p">].</span><span class="nx">isEditable</span><span class="p">);</span></div><div class='line' id='LC98'>			<span class="p">}</span></div><div class='line' id='LC99'><br/></div><div class='line' id='LC100'>			<span class="c1">// Defaults</span></div><div class='line' id='LC101'>			<span class="nx">type</span> <span class="o">=</span> <span class="nx">type</span> <span class="o">||</span> <span class="s1">&#39;buynow&#39;</span><span class="p">;</span></div><div class='line' id='LC102'>			<span class="nx">env</span> <span class="o">=</span> <span class="s2">&quot;www&quot;</span><span class="p">;</span></div><div class='line' id='LC103'>			<span class="k">if</span> <span class="p">(</span><span class="nx">data</span><span class="p">.</span><span class="nx">items</span><span class="p">.</span><span class="nx">env</span> <span class="o">&amp;&amp;</span> <span class="nx">data</span><span class="p">.</span><span class="nx">items</span><span class="p">.</span><span class="nx">env</span><span class="p">.</span><span class="nx">value</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC104'>				<span class="nx">env</span> <span class="o">+=</span> <span class="s2">&quot;.&quot;</span> <span class="o">+</span> <span class="nx">data</span><span class="p">.</span><span class="nx">items</span><span class="p">.</span><span class="nx">env</span><span class="p">.</span><span class="nx">value</span><span class="p">;</span></div><div class='line' id='LC105'>			<span class="p">}</span></div><div class='line' id='LC106'><br/></div><div class='line' id='LC107'>			<span class="c1">// Cart buttons</span></div><div class='line' id='LC108'>			<span class="k">if</span> <span class="p">(</span><span class="nx">type</span> <span class="o">===</span> <span class="s1">&#39;cart&#39;</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC109'>				<span class="nx">data</span><span class="p">.</span><span class="nx">add</span><span class="p">(</span><span class="s1">&#39;cmd&#39;</span><span class="p">,</span> <span class="s1">&#39;_cart&#39;</span><span class="p">);</span></div><div class='line' id='LC110'>				<span class="nx">data</span><span class="p">.</span><span class="nx">add</span><span class="p">(</span><span class="s1">&#39;add&#39;</span><span class="p">,</span> <span class="kc">true</span><span class="p">);</span></div><div class='line' id='LC111'>			<span class="c1">// Donation buttons</span></div><div class='line' id='LC112'>			<span class="p">}</span> <span class="k">else</span> <span class="k">if</span> <span class="p">(</span><span class="nx">type</span> <span class="o">===</span> <span class="s1">&#39;donate&#39;</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC113'>				<span class="nx">data</span><span class="p">.</span><span class="nx">add</span><span class="p">(</span><span class="s1">&#39;cmd&#39;</span><span class="p">,</span> <span class="s1">&#39;_donations&#39;</span><span class="p">);</span></div><div class='line' id='LC114'>			<span class="c1">// Subscribe buttons</span></div><div class='line' id='LC115'>			<span class="p">}</span> <span class="k">else</span> <span class="k">if</span> <span class="p">(</span><span class="nx">type</span> <span class="o">===</span> <span class="s1">&#39;subscribe&#39;</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC116'>				<span class="nx">data</span><span class="p">.</span><span class="nx">add</span><span class="p">(</span><span class="s1">&#39;cmd&#39;</span><span class="p">,</span> <span class="s1">&#39;_xclick-subscriptions&#39;</span><span class="p">);</span></div><div class='line' id='LC117'><br/></div><div class='line' id='LC118'>				<span class="c1">// TODO: &quot;amount&quot; cannot be used in prettyParams since it&#39;s overloaded</span></div><div class='line' id='LC119'>				<span class="c1">// Find a better way to do this</span></div><div class='line' id='LC120'>				<span class="k">if</span> <span class="p">(</span><span class="nx">data</span><span class="p">.</span><span class="nx">items</span><span class="p">.</span><span class="nx">amount</span> <span class="o">&amp;&amp;</span> <span class="o">!</span><span class="nx">data</span><span class="p">.</span><span class="nx">items</span><span class="p">.</span><span class="nx">a3</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC121'>					<span class="nx">data</span><span class="p">.</span><span class="nx">add</span><span class="p">(</span><span class="s1">&#39;a3&#39;</span><span class="p">,</span> <span class="nx">data</span><span class="p">.</span><span class="nx">items</span><span class="p">.</span><span class="nx">amount</span><span class="p">.</span><span class="nx">value</span><span class="p">);</span></div><div class='line' id='LC122'>				<span class="p">}</span></div><div class='line' id='LC123'>			<span class="c1">// Buy Now buttons</span></div><div class='line' id='LC124'>			<span class="p">}</span> <span class="k">else</span> <span class="p">{</span></div><div class='line' id='LC125'>				<span class="nx">data</span><span class="p">.</span><span class="nx">add</span><span class="p">(</span><span class="s1">&#39;cmd&#39;</span><span class="p">,</span> <span class="s1">&#39;_xclick&#39;</span><span class="p">);</span></div><div class='line' id='LC126'>			<span class="p">}</span></div><div class='line' id='LC127'><br/></div><div class='line' id='LC128'>			<span class="c1">// Add common data</span></div><div class='line' id='LC129'>			<span class="nx">data</span><span class="p">.</span><span class="nx">add</span><span class="p">(</span><span class="s1">&#39;business&#39;</span><span class="p">,</span> <span class="nx">business</span><span class="p">);</span></div><div class='line' id='LC130'>			<span class="nx">data</span><span class="p">.</span><span class="nx">add</span><span class="p">(</span><span class="s1">&#39;bn&#39;</span><span class="p">,</span> <span class="nx">bnCode</span><span class="p">.</span><span class="nx">replace</span><span class="p">(</span><span class="sr">/\{type\}/</span><span class="p">,</span> <span class="nx">type</span><span class="p">));</span></div><div class='line' id='LC131'>			<span class="nx">data</span><span class="p">.</span><span class="nx">add</span><span class="p">(</span><span class="s1">&#39;env&#39;</span><span class="p">,</span>  <span class="nx">env</span><span class="p">);</span></div><div class='line' id='LC132'><br/></div><div class='line' id='LC133'>			<span class="c1">// Build the UI components</span></div><div class='line' id='LC134'>			<span class="k">if</span> <span class="p">(</span><span class="nx">type</span> <span class="o">===</span> <span class="s1">&#39;qr&#39;</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC135'>				<span class="nx">button</span> <span class="o">=</span> <span class="nx">buildQR</span><span class="p">(</span><span class="nx">data</span><span class="p">,</span> <span class="nx">data</span><span class="p">.</span><span class="nx">items</span><span class="p">.</span><span class="nx">size</span><span class="p">);</span></div><div class='line' id='LC136'>				<span class="nx">data</span><span class="p">.</span><span class="nx">remove</span><span class="p">(</span><span class="s1">&#39;size&#39;</span><span class="p">);</span></div><div class='line' id='LC137'>			<span class="p">}</span> <span class="k">else</span> <span class="p">{</span></div><div class='line' id='LC138'>				<span class="nx">button</span> <span class="o">=</span> <span class="nx">buildForm</span><span class="p">(</span><span class="nx">data</span><span class="p">,</span> <span class="nx">type</span><span class="p">);</span></div><div class='line' id='LC139'>			<span class="p">}</span></div><div class='line' id='LC140'><br/></div><div class='line' id='LC141'>			<span class="c1">// Inject CSS</span></div><div class='line' id='LC142'>			<span class="nx">injectCSS</span><span class="p">();</span></div><div class='line' id='LC143'><br/></div><div class='line' id='LC144'>			<span class="c1">// Register it</span></div><div class='line' id='LC145'>			<span class="k">this</span><span class="p">.</span><span class="nx">buttons</span><span class="p">[</span><span class="nx">type</span><span class="p">]</span> <span class="o">+=</span> <span class="mi">1</span><span class="p">;</span></div><div class='line' id='LC146'><br/></div><div class='line' id='LC147'>			<span class="c1">// Add it to the DOM</span></div><div class='line' id='LC148'>			<span class="k">if</span> <span class="p">(</span><span class="nx">parent</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC149'>				<span class="nx">parent</span><span class="p">.</span><span class="nx">appendChild</span><span class="p">(</span><span class="nx">button</span><span class="p">);</span></div><div class='line' id='LC150'>			<span class="p">}</span></div><div class='line' id='LC151'><br/></div><div class='line' id='LC152'>			<span class="k">return</span> <span class="nx">button</span><span class="p">;</span></div><div class='line' id='LC153'>		<span class="p">};</span></div><div class='line' id='LC154'><br/></div><div class='line' id='LC155'><br/></div><div class='line' id='LC156'>		<span class="nx">PAYPAL</span><span class="p">.</span><span class="nx">apps</span><span class="p">.</span><span class="nx">ButtonFactory</span> <span class="o">=</span> <span class="nx">app</span><span class="p">;</span></div><div class='line' id='LC157'>	<span class="p">}</span></div><div class='line' id='LC158'><br/></div><div class='line' id='LC159'><br/></div><div class='line' id='LC160'>	<span class="cm">/**</span></div><div class='line' id='LC161'><span class="cm">	 * Injects button CSS in the &lt;head&gt;</span></div><div class='line' id='LC162'><span class="cm">	 *</span></div><div class='line' id='LC163'><span class="cm">	 * @return {void}</span></div><div class='line' id='LC164'><span class="cm">	 */</span></div><div class='line' id='LC165'>	<span class="kd">function</span> <span class="nx">injectCSS</span><span class="p">()</span> <span class="p">{</span></div><div class='line' id='LC166'>		<span class="kd">var</span> <span class="nx">css</span><span class="p">,</span> <span class="nx">styleEl</span><span class="p">,</span> <span class="nx">paypalButton</span><span class="p">,</span> <span class="nx">paypalInput</span><span class="p">;</span></div><div class='line' id='LC167'><br/></div><div class='line' id='LC168'>		<span class="k">if</span> <span class="p">(</span><span class="nb">document</span><span class="p">.</span><span class="nx">getElementById</span><span class="p">(</span><span class="s1">&#39;paypal-button&#39;</span><span class="p">))</span> <span class="p">{</span></div><div class='line' id='LC169'>			<span class="k">return</span><span class="p">;</span></div><div class='line' id='LC170'>		<span class="p">}</span></div><div class='line' id='LC171'><br/></div><div class='line' id='LC172'>		<span class="nx">css</span> <span class="o">=</span> <span class="s1">&#39;&#39;</span><span class="p">;</span></div><div class='line' id='LC173'>		<span class="nx">styleEl</span> <span class="o">=</span> <span class="nb">document</span><span class="p">.</span><span class="nx">createElement</span><span class="p">(</span><span class="s1">&#39;style&#39;</span><span class="p">);</span></div><div class='line' id='LC174'>		<span class="nx">paypalButton</span> <span class="o">=</span> <span class="s1">&#39;.paypal-button&#39;</span><span class="p">;</span></div><div class='line' id='LC175'>		<span class="nx">paypalInput</span> <span class="o">=</span> <span class="nx">paypalButton</span> <span class="o">+</span> <span class="s1">&#39; button&#39;</span><span class="p">;</span></div><div class='line' id='LC176'><br/></div><div class='line' id='LC177'>		<span class="nx">css</span> <span class="o">+=</span> <span class="nx">paypalButton</span> <span class="o">+</span> <span class="s1">&#39; { white-space: nowrap; }&#39;</span><span class="p">;</span></div><div class='line' id='LC178'>		<span class="nx">css</span> <span class="o">+=</span> <span class="nx">paypalInput</span> <span class="o">+</span> <span class="s1">&#39; { white-space: nowrap; overflow: hidden; border-radius: 13px; font-family: &quot;Arial&quot;, bold, italic; font-weight: bold; font-style: italic; border: 1px solid #ffa823; color: #0E3168; background: #ffa823; position: relative; text-shadow: 0 1px 0 rgba(255,255,255,.5); cursor: pointer; z-index: 0; }&#39;</span><span class="p">;</span></div><div class='line' id='LC179'>		<span class="nx">css</span> <span class="o">+=</span> <span class="nx">paypalInput</span> <span class="o">+</span> <span class="s1">&#39;:before { content: &quot; &quot;; position: absolute; width: 100%; height: 100%; border-radius: 11px; top: 0; left: 0; background: #ffa823; background: -webkit-linear-gradient(top, #FFAA00 0%,#FFAA00 80%,#FFF8FC 100%); background: -moz-linear-gradient(top, #FFAA00 0%,#FFAA00 80%,#FFF8FC 100%); background: -ms-linear-gradient(top, #FFAA00 0%,#FFAA00 80%,#FFF8FC 100%); background: linear-gradient(top, #FFAA00 0%,#FFAA00 80%,#FFF8FC 100%); z-index: -2; }&#39;</span><span class="p">;</span></div><div class='line' id='LC180'>		<span class="nx">css</span> <span class="o">+=</span> <span class="nx">paypalInput</span> <span class="o">+</span> <span class="s1">&#39;:after { content: &quot; &quot;; position: absolute; width: 98%; height: 60%; border-radius: 40px 40px 38px 38px; top: 0; left: 0; background: -webkit-linear-gradient(top, #fefefe 0%, #fed994 100%); background: -moz-linear-gradient(top, #fefefe 0%, #fed994 100%); background: -ms-linear-gradient(top, #fefefe 0%, #fed994 100%); background: linear-gradient(top, #fefefe 0%, #fed994 100%); z-index: -1; -webkit-transform: translateX(1%);-moz-transform: translateX(1%); -ms-transform: translateX(1%); transform: translateX(1%); }&#39;</span><span class="p">;</span></div><div class='line' id='LC181'>		<span class="nx">css</span> <span class="o">+=</span> <span class="nx">paypalInput</span> <span class="o">+</span> <span class="s1">&#39;.small { padding: 3px 15px; font-size: 12px; }&#39;</span><span class="p">;</span></div><div class='line' id='LC182'>		<span class="nx">css</span> <span class="o">+=</span> <span class="nx">paypalInput</span> <span class="o">+</span> <span class="s1">&#39;.large { padding: 4px 19px; font-size: 14px; }&#39;</span><span class="p">;</span></div><div class='line' id='LC183'><br/></div><div class='line' id='LC184'>		<span class="nx">styleEl</span><span class="p">.</span><span class="nx">type</span> <span class="o">=</span> <span class="s1">&#39;text/css&#39;</span><span class="p">;</span></div><div class='line' id='LC185'>		<span class="nx">styleEl</span><span class="p">.</span><span class="nx">id</span> <span class="o">=</span> <span class="s1">&#39;paypal-button&#39;</span><span class="p">;</span></div><div class='line' id='LC186'><br/></div><div class='line' id='LC187'>		<span class="k">if</span> <span class="p">(</span><span class="nx">styleEl</span><span class="p">.</span><span class="nx">styleSheet</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC188'>			<span class="nx">styleEl</span><span class="p">.</span><span class="nx">styleSheet</span><span class="p">.</span><span class="nx">cssText</span> <span class="o">=</span> <span class="nx">css</span><span class="p">;</span></div><div class='line' id='LC189'>		<span class="p">}</span> <span class="k">else</span> <span class="p">{</span></div><div class='line' id='LC190'>			<span class="nx">styleEl</span><span class="p">.</span><span class="nx">appendChild</span><span class="p">(</span><span class="nb">document</span><span class="p">.</span><span class="nx">createTextNode</span><span class="p">(</span><span class="nx">css</span><span class="p">));</span></div><div class='line' id='LC191'>		<span class="p">}</span></div><div class='line' id='LC192'><br/></div><div class='line' id='LC193'>		<span class="nb">document</span><span class="p">.</span><span class="nx">getElementsByTagName</span><span class="p">(</span><span class="s1">&#39;head&#39;</span><span class="p">)[</span><span class="mi">0</span><span class="p">].</span><span class="nx">appendChild</span><span class="p">(</span><span class="nx">styleEl</span><span class="p">);</span></div><div class='line' id='LC194'>	<span class="p">}</span></div><div class='line' id='LC195'><br/></div><div class='line' id='LC196'><br/></div><div class='line' id='LC197'>	<span class="cm">/**</span></div><div class='line' id='LC198'><span class="cm">	 * Builds the form DOM structure for a button</span></div><div class='line' id='LC199'><span class="cm">	 *</span></div><div class='line' id='LC200'><span class="cm">	 * @param data {Object} An object of key/value data to set as button params</span></div><div class='line' id='LC201'><span class="cm">	 * @param type (String) The type of the button to render</span></div><div class='line' id='LC202'><span class="cm">	 * @return {HTMLElement}</span></div><div class='line' id='LC203'><span class="cm">	 */</span></div><div class='line' id='LC204'>	<span class="kd">function</span> <span class="nx">buildForm</span><span class="p">(</span><span class="nx">data</span><span class="p">,</span> <span class="nx">type</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC205'>		<span class="kd">var</span> <span class="nx">form</span> <span class="o">=</span> <span class="nb">document</span><span class="p">.</span><span class="nx">createElement</span><span class="p">(</span><span class="s1">&#39;form&#39;</span><span class="p">),</span></div><div class='line' id='LC206'>			<span class="nx">btn</span> <span class="o">=</span> <span class="nb">document</span><span class="p">.</span><span class="nx">createElement</span><span class="p">(</span><span class="s1">&#39;button&#39;</span><span class="p">),</span></div><div class='line' id='LC207'>			<span class="nx">hidden</span> <span class="o">=</span> <span class="nb">document</span><span class="p">.</span><span class="nx">createElement</span><span class="p">(</span><span class="s1">&#39;input&#39;</span><span class="p">),</span></div><div class='line' id='LC208'>			<span class="nx">items</span> <span class="o">=</span> <span class="nx">data</span><span class="p">.</span><span class="nx">items</span><span class="p">,</span></div><div class='line' id='LC209'>			<span class="nx">item</span><span class="p">,</span> <span class="nx">child</span><span class="p">,</span> <span class="nx">label</span><span class="p">,</span> <span class="nx">input</span><span class="p">,</span> <span class="nx">key</span><span class="p">,</span> <span class="nx">size</span><span class="p">,</span> <span class="nx">locale</span><span class="p">,</span> <span class="nx">localeText</span><span class="p">;</span></div><div class='line' id='LC210'><br/></div><div class='line' id='LC211'>		<span class="nx">form</span><span class="p">.</span><span class="nx">method</span> <span class="o">=</span> <span class="s1">&#39;post&#39;</span><span class="p">;</span></div><div class='line' id='LC212'>		<span class="nx">form</span><span class="p">.</span><span class="nx">action</span> <span class="o">=</span> <span class="nx">paypalURL</span><span class="p">.</span><span class="nx">replace</span><span class="p">(</span><span class="s1">&#39;{env}&#39;</span><span class="p">,</span> <span class="nx">data</span><span class="p">.</span><span class="nx">items</span><span class="p">.</span><span class="nx">env</span><span class="p">.</span><span class="nx">value</span><span class="p">);</span></div><div class='line' id='LC213'>		<span class="nx">form</span><span class="p">.</span><span class="nx">className</span> <span class="o">=</span> <span class="s1">&#39;paypal-button&#39;</span><span class="p">;</span></div><div class='line' id='LC214'>		<span class="nx">form</span><span class="p">.</span><span class="nx">target</span> <span class="o">=</span> <span class="s1">&#39;_top&#39;</span><span class="p">;</span></div><div class='line' id='LC215'><br/></div><div class='line' id='LC216'>		<span class="nx">hidden</span><span class="p">.</span><span class="nx">type</span> <span class="o">=</span> <span class="s1">&#39;hidden&#39;</span><span class="p">;</span></div><div class='line' id='LC217'><br/></div><div class='line' id='LC218'>		<span class="nx">size</span> <span class="o">=</span> <span class="nx">items</span><span class="p">.</span><span class="nx">size</span> <span class="o">&amp;&amp;</span> <span class="nx">items</span><span class="p">.</span><span class="nx">size</span><span class="p">.</span><span class="nx">value</span> <span class="o">||</span> <span class="s1">&#39;large&#39;</span><span class="p">;</span></div><div class='line' id='LC219'>		<span class="nx">locale</span> <span class="o">=</span> <span class="nx">items</span><span class="p">.</span><span class="nx">lc</span> <span class="o">&amp;&amp;</span> <span class="nx">items</span><span class="p">.</span><span class="nx">lc</span><span class="p">.</span><span class="nx">value</span> <span class="o">||</span> <span class="s1">&#39;en_US&#39;</span><span class="p">;</span></div><div class='line' id='LC220'>		<span class="nx">localeText</span> <span class="o">=</span> <span class="nx">locales</span><span class="p">[</span><span class="nx">locale</span><span class="p">]</span> <span class="o">||</span> <span class="nx">locales</span><span class="p">.</span><span class="nx">en_US</span><span class="p">;</span></div><div class='line' id='LC221'><br/></div><div class='line' id='LC222'>		<span class="k">for</span> <span class="p">(</span><span class="nx">key</span> <span class="k">in</span> <span class="nx">items</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC223'>			<span class="nx">item</span> <span class="o">=</span> <span class="nx">items</span><span class="p">[</span><span class="nx">key</span><span class="p">];</span></div><div class='line' id='LC224'><br/></div><div class='line' id='LC225'>			<span class="k">if</span> <span class="p">(</span><span class="nx">item</span><span class="p">.</span><span class="nx">isEditable</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC226'>				<span class="nx">input</span> <span class="o">=</span> <span class="nb">document</span><span class="p">.</span><span class="nx">createElement</span><span class="p">(</span><span class="s1">&#39;input&#39;</span><span class="p">);</span></div><div class='line' id='LC227'>				<span class="nx">input</span><span class="p">.</span><span class="nx">type</span> <span class="o">=</span> <span class="s1">&#39;text&#39;</span><span class="p">;</span></div><div class='line' id='LC228'>				<span class="nx">input</span><span class="p">.</span><span class="nx">className</span> <span class="o">=</span> <span class="s1">&#39;paypal-input&#39;</span><span class="p">;</span></div><div class='line' id='LC229'>				<span class="nx">input</span><span class="p">.</span><span class="nx">name</span> <span class="o">=</span> <span class="nx">item</span><span class="p">.</span><span class="nx">key</span><span class="p">;</span></div><div class='line' id='LC230'>				<span class="nx">input</span><span class="p">.</span><span class="nx">value</span> <span class="o">=</span> <span class="nx">item</span><span class="p">.</span><span class="nx">value</span><span class="p">;</span></div><div class='line' id='LC231'><br/></div><div class='line' id='LC232'>				<span class="nx">label</span> <span class="o">=</span> <span class="nb">document</span><span class="p">.</span><span class="nx">createElement</span><span class="p">(</span><span class="s1">&#39;label&#39;</span><span class="p">);</span></div><div class='line' id='LC233'>				<span class="nx">label</span><span class="p">.</span><span class="nx">className</span> <span class="o">=</span> <span class="s1">&#39;paypal-label&#39;</span><span class="p">;</span></div><div class='line' id='LC234'>				<span class="nx">label</span><span class="p">.</span><span class="nx">appendChild</span><span class="p">(</span><span class="nb">document</span><span class="p">.</span><span class="nx">createTextNode</span><span class="p">(</span><span class="nx">app</span><span class="p">.</span><span class="nx">config</span><span class="p">.</span><span class="nx">labels</span><span class="p">[</span><span class="nx">item</span><span class="p">.</span><span class="nx">key</span><span class="p">]</span> <span class="o">||</span> <span class="nx">localeText</span><span class="p">[</span><span class="nx">item</span><span class="p">.</span><span class="nx">key</span><span class="p">]));</span></div><div class='line' id='LC235'>				<span class="nx">label</span><span class="p">.</span><span class="nx">appendChild</span><span class="p">(</span><span class="nx">input</span><span class="p">);</span></div><div class='line' id='LC236'><br/></div><div class='line' id='LC237'>				<span class="nx">child</span> <span class="o">=</span> <span class="nb">document</span><span class="p">.</span><span class="nx">createElement</span><span class="p">(</span><span class="s1">&#39;p&#39;</span><span class="p">);</span></div><div class='line' id='LC238'>				<span class="nx">child</span><span class="p">.</span><span class="nx">className</span> <span class="o">=</span> <span class="s1">&#39;paypal-group&#39;</span><span class="p">;</span></div><div class='line' id='LC239'>				<span class="nx">child</span><span class="p">.</span><span class="nx">appendChild</span><span class="p">(</span><span class="nx">label</span><span class="p">);</span></div><div class='line' id='LC240'>			<span class="p">}</span> <span class="k">else</span> <span class="p">{</span></div><div class='line' id='LC241'>				<span class="nx">input</span> <span class="o">=</span> <span class="nx">child</span> <span class="o">=</span> <span class="nx">hidden</span><span class="p">.</span><span class="nx">cloneNode</span><span class="p">(</span><span class="kc">true</span><span class="p">);</span></div><div class='line' id='LC242'>				<span class="nx">input</span><span class="p">.</span><span class="nx">name</span> <span class="o">=</span> <span class="nx">item</span><span class="p">.</span><span class="nx">key</span><span class="p">;</span></div><div class='line' id='LC243'>				<span class="nx">input</span><span class="p">.</span><span class="nx">value</span> <span class="o">=</span> <span class="nx">item</span><span class="p">.</span><span class="nx">value</span><span class="p">;</span></div><div class='line' id='LC244'>			<span class="p">}</span></div><div class='line' id='LC245'><br/></div><div class='line' id='LC246'>			<span class="nx">form</span><span class="p">.</span><span class="nx">appendChild</span><span class="p">(</span><span class="nx">child</span><span class="p">);</span></div><div class='line' id='LC247'>		<span class="p">}</span></div><div class='line' id='LC248'><br/></div><div class='line' id='LC249'>		<span class="c1">// Safari won&#39;t let you set read-only attributes on buttons.</span></div><div class='line' id='LC250'>		<span class="k">try</span> <span class="p">{</span></div><div class='line' id='LC251'>			<span class="nx">btn</span><span class="p">.</span><span class="nx">type</span> <span class="o">=</span> <span class="s1">&#39;submit&#39;</span><span class="p">;</span></div><div class='line' id='LC252'>		<span class="p">}</span> <span class="k">catch</span> <span class="p">(</span><span class="nx">e</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC253'>			<span class="nx">btn</span><span class="p">.</span><span class="nx">setAttribute</span><span class="p">(</span><span class="s1">&#39;type&#39;</span><span class="p">,</span> <span class="s1">&#39;submit&#39;</span><span class="p">);</span></div><div class='line' id='LC254'>		<span class="p">}</span></div><div class='line' id='LC255'>		<span class="nx">btn</span><span class="p">.</span><span class="nx">className</span> <span class="o">=</span> <span class="s1">&#39;paypal-button &#39;</span> <span class="o">+</span> <span class="nx">size</span><span class="p">;</span></div><div class='line' id='LC256'>		<span class="nx">btn</span><span class="p">.</span><span class="nx">appendChild</span><span class="p">(</span><span class="nb">document</span><span class="p">.</span><span class="nx">createTextNode</span><span class="p">(</span><span class="nx">localeText</span><span class="p">[</span><span class="nx">type</span><span class="p">]));</span></div><div class='line' id='LC257'><br/></div><div class='line' id='LC258'>		<span class="nx">form</span><span class="p">.</span><span class="nx">appendChild</span><span class="p">(</span><span class="nx">btn</span><span class="p">);</span></div><div class='line' id='LC259'><br/></div><div class='line' id='LC260'>		<span class="c1">// If the Mini Cart is present then register the form</span></div><div class='line' id='LC261'>		<span class="k">if</span> <span class="p">(</span><span class="nx">PAYPAL</span><span class="p">.</span><span class="nx">apps</span><span class="p">.</span><span class="nx">MiniCart</span> <span class="o">&amp;&amp;</span> <span class="nx">data</span><span class="p">.</span><span class="nx">items</span><span class="p">.</span><span class="nx">cmd</span><span class="p">.</span><span class="nx">value</span> <span class="o">===</span> <span class="s1">&#39;_cart&#39;</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC262'>			<span class="kd">var</span> <span class="nx">MiniCart</span> <span class="o">=</span> <span class="nx">PAYPAL</span><span class="p">.</span><span class="nx">apps</span><span class="p">.</span><span class="nx">MiniCart</span><span class="p">;</span></div><div class='line' id='LC263'><br/></div><div class='line' id='LC264'>			<span class="k">if</span> <span class="p">(</span><span class="o">!</span><span class="nx">MiniCart</span><span class="p">.</span><span class="nx">UI</span><span class="p">.</span><span class="nx">itemList</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC265'>				<span class="nx">MiniCart</span><span class="p">.</span><span class="nx">render</span><span class="p">();</span></div><div class='line' id='LC266'>			<span class="p">}</span></div><div class='line' id='LC267'><br/></div><div class='line' id='LC268'>			<span class="nx">MiniCart</span><span class="p">.</span><span class="nx">bindForm</span><span class="p">(</span><span class="nx">form</span><span class="p">);</span></div><div class='line' id='LC269'>		<span class="p">}</span></div><div class='line' id='LC270'><br/></div><div class='line' id='LC271'>		<span class="k">return</span> <span class="nx">form</span><span class="p">;</span></div><div class='line' id='LC272'>	<span class="p">}</span></div><div class='line' id='LC273'><br/></div><div class='line' id='LC274'><br/></div><div class='line' id='LC275'>	<span class="cm">/**</span></div><div class='line' id='LC276'><span class="cm">	 * Builds the image for a QR code</span></div><div class='line' id='LC277'><span class="cm">	 *</span></div><div class='line' id='LC278'><span class="cm">	 * @param data {Object} An object of key/value data to set as button params</span></div><div class='line' id='LC279'><span class="cm">	 * @param size {String} The size of QR code&#39;s longest side</span></div><div class='line' id='LC280'><span class="cm">	 * @return {HTMLElement}</span></div><div class='line' id='LC281'><span class="cm">	 */</span></div><div class='line' id='LC282'>	<span class="kd">function</span> <span class="nx">buildQR</span><span class="p">(</span><span class="nx">data</span><span class="p">,</span> <span class="nx">size</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC283'>		<span class="kd">var</span> <span class="nx">baseUrl</span> <span class="o">=</span> <span class="nx">paypalURL</span><span class="p">.</span><span class="nx">replace</span><span class="p">(</span><span class="s1">&#39;{env}&#39;</span><span class="p">,</span> <span class="nx">data</span><span class="p">.</span><span class="nx">items</span><span class="p">.</span><span class="nx">env</span><span class="p">.</span><span class="nx">value</span><span class="p">);</span></div><div class='line' id='LC284'><br/></div><div class='line' id='LC285'>		<span class="kd">var</span> <span class="nx">img</span> <span class="o">=</span> <span class="nb">document</span><span class="p">.</span><span class="nx">createElement</span><span class="p">(</span><span class="s1">&#39;img&#39;</span><span class="p">),</span></div><div class='line' id='LC286'>			<span class="nx">url</span> <span class="o">=</span> <span class="nx">baseUrl</span> <span class="o">+</span> <span class="s1">&#39;?&#39;</span><span class="p">,</span></div><div class='line' id='LC287'>			<span class="nx">pattern</span> <span class="o">=</span> <span class="mi">13</span><span class="p">,</span></div><div class='line' id='LC288'>			<span class="nx">items</span> <span class="o">=</span> <span class="nx">data</span><span class="p">.</span><span class="nx">items</span><span class="p">,</span></div><div class='line' id='LC289'>			<span class="nx">item</span><span class="p">,</span> <span class="nx">key</span><span class="p">;</span></div><div class='line' id='LC290'><br/></div><div class='line' id='LC291'>		<span class="c1">// QR defaults</span></div><div class='line' id='LC292'>		<span class="nx">size</span> <span class="o">=</span> <span class="nx">size</span> <span class="o">&amp;&amp;</span> <span class="nx">size</span><span class="p">.</span><span class="nx">value</span> <span class="o">||</span> <span class="mi">250</span><span class="p">;</span></div><div class='line' id='LC293'><br/></div><div class='line' id='LC294'>		<span class="k">for</span> <span class="p">(</span><span class="nx">key</span> <span class="k">in</span> <span class="nx">items</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC295'>			<span class="nx">item</span> <span class="o">=</span> <span class="nx">items</span><span class="p">[</span><span class="nx">key</span><span class="p">];</span></div><div class='line' id='LC296'>			<span class="nx">url</span> <span class="o">+=</span> <span class="nx">item</span><span class="p">.</span><span class="nx">key</span> <span class="o">+</span> <span class="s1">&#39;=&#39;</span> <span class="o">+</span> <span class="nb">encodeURIComponent</span><span class="p">(</span><span class="nx">item</span><span class="p">.</span><span class="nx">value</span><span class="p">)</span> <span class="o">+</span> <span class="s1">&#39;&amp;&#39;</span><span class="p">;</span></div><div class='line' id='LC297'>		<span class="p">}</span></div><div class='line' id='LC298'><br/></div><div class='line' id='LC299'>		<span class="nx">url</span> <span class="o">=</span> <span class="nb">encodeURIComponent</span><span class="p">(</span><span class="nx">url</span><span class="p">);</span></div><div class='line' id='LC300'>		<span class="nx">img</span><span class="p">.</span><span class="nx">src</span> <span class="o">=</span> <span class="nx">qrCodeURL</span><span class="p">.</span><span class="nx">replace</span><span class="p">(</span><span class="s1">&#39;{env}&#39;</span><span class="p">,</span> <span class="nx">data</span><span class="p">.</span><span class="nx">items</span><span class="p">.</span><span class="nx">env</span><span class="p">.</span><span class="nx">value</span><span class="p">).</span><span class="nx">replace</span><span class="p">(</span><span class="s1">&#39;{url}&#39;</span><span class="p">,</span> <span class="nx">url</span><span class="p">).</span><span class="nx">replace</span><span class="p">(</span><span class="s1">&#39;{pattern}&#39;</span><span class="p">,</span> <span class="nx">pattern</span><span class="p">).</span><span class="nx">replace</span><span class="p">(</span><span class="s1">&#39;{size}&#39;</span><span class="p">,</span> <span class="nx">size</span><span class="p">);</span></div><div class='line' id='LC301'>		<span class="k">return</span> <span class="nx">img</span><span class="p">;</span></div><div class='line' id='LC302'>	<span class="p">}</span></div><div class='line' id='LC303'><br/></div><div class='line' id='LC304'><br/></div><div class='line' id='LC305'>	<span class="cm">/**</span></div><div class='line' id='LC306'><span class="cm">	 * Utility function to polyfill dataset functionality with a bit of a spin</span></div><div class='line' id='LC307'><span class="cm">	 *</span></div><div class='line' id='LC308'><span class="cm">	 * @param el {HTMLElement} The element to check</span></div><div class='line' id='LC309'><span class="cm">	 * @return {Object}</span></div><div class='line' id='LC310'><span class="cm">	 */</span></div><div class='line' id='LC311'>	<span class="kd">function</span> <span class="nx">getDataSet</span><span class="p">(</span><span class="nx">el</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC312'>		<span class="kd">var</span> <span class="nx">dataset</span> <span class="o">=</span> <span class="p">{},</span> <span class="nx">attrs</span><span class="p">,</span> <span class="nx">attr</span><span class="p">,</span> <span class="nx">matches</span><span class="p">,</span> <span class="nx">len</span><span class="p">,</span> <span class="nx">i</span><span class="p">;</span></div><div class='line' id='LC313'><br/></div><div class='line' id='LC314'>		<span class="k">if</span> <span class="p">((</span><span class="nx">attrs</span> <span class="o">=</span> <span class="nx">el</span><span class="p">.</span><span class="nx">attributes</span><span class="p">))</span> <span class="p">{</span></div><div class='line' id='LC315'>			<span class="k">for</span> <span class="p">(</span><span class="nx">i</span> <span class="o">=</span> <span class="mi">0</span><span class="p">,</span> <span class="nx">len</span> <span class="o">=</span> <span class="nx">attrs</span><span class="p">.</span><span class="nx">length</span><span class="p">;</span> <span class="nx">i</span> <span class="o">&lt;</span> <span class="nx">len</span><span class="p">;</span> <span class="nx">i</span><span class="o">++</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC316'>				<span class="nx">attr</span> <span class="o">=</span> <span class="nx">attrs</span><span class="p">[</span><span class="nx">i</span><span class="p">];</span></div><div class='line' id='LC317'><br/></div><div class='line' id='LC318'>				<span class="k">if</span> <span class="p">((</span><span class="nx">matches</span> <span class="o">=</span> <span class="sr">/^data-([a-z0-9_]+)(-editable)?/i</span><span class="p">.</span><span class="nx">exec</span><span class="p">(</span><span class="nx">attr</span><span class="p">.</span><span class="nx">name</span><span class="p">)))</span> <span class="p">{</span></div><div class='line' id='LC319'>					<span class="nx">dataset</span><span class="p">[</span><span class="nx">matches</span><span class="p">[</span><span class="mi">1</span><span class="p">]]</span> <span class="o">=</span> <span class="p">{</span></div><div class='line' id='LC320'>						<span class="nx">value</span><span class="o">:</span> <span class="nx">attr</span><span class="p">.</span><span class="nx">value</span><span class="p">,</span></div><div class='line' id='LC321'>						<span class="nx">isEditable</span><span class="o">:</span> <span class="o">!!</span><span class="nx">matches</span><span class="p">[</span><span class="mi">2</span><span class="p">]</span></div><div class='line' id='LC322'>					<span class="p">};</span></div><div class='line' id='LC323'>				<span class="p">}</span></div><div class='line' id='LC324'>			<span class="p">}</span></div><div class='line' id='LC325'>		<span class="p">}</span></div><div class='line' id='LC326'><br/></div><div class='line' id='LC327'>		<span class="k">return</span> <span class="nx">dataset</span><span class="p">;</span></div><div class='line' id='LC328'>	<span class="p">}</span></div><div class='line' id='LC329'><br/></div><div class='line' id='LC330'><br/></div><div class='line' id='LC331'>	<span class="cm">/**</span></div><div class='line' id='LC332'><span class="cm">	 * A storage object to create structured methods around a button&#39;s data</span></div><div class='line' id='LC333'><span class="cm">	 */</span></div><div class='line' id='LC334'>	<span class="kd">function</span> <span class="nx">DataStore</span><span class="p">()</span> <span class="p">{</span></div><div class='line' id='LC335'>		<span class="k">this</span><span class="p">.</span><span class="nx">items</span> <span class="o">=</span> <span class="p">{};</span></div><div class='line' id='LC336'><br/></div><div class='line' id='LC337'>		<span class="k">this</span><span class="p">.</span><span class="nx">add</span> <span class="o">=</span> <span class="kd">function</span> <span class="p">(</span><span class="nx">key</span><span class="p">,</span> <span class="nx">value</span><span class="p">,</span> <span class="nx">isEditable</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC338'>			<span class="k">this</span><span class="p">.</span><span class="nx">items</span><span class="p">[</span><span class="nx">key</span><span class="p">]</span> <span class="o">=</span> <span class="p">{</span></div><div class='line' id='LC339'>				<span class="nx">key</span><span class="o">:</span> <span class="nx">key</span><span class="p">,</span></div><div class='line' id='LC340'>				<span class="nx">value</span><span class="o">:</span> <span class="nx">value</span><span class="p">,</span></div><div class='line' id='LC341'>				<span class="nx">isEditable</span><span class="o">:</span> <span class="nx">isEditable</span></div><div class='line' id='LC342'>			<span class="p">};</span></div><div class='line' id='LC343'>		<span class="p">};</span></div><div class='line' id='LC344'><br/></div><div class='line' id='LC345'>		<span class="k">this</span><span class="p">.</span><span class="nx">remove</span> <span class="o">=</span> <span class="kd">function</span> <span class="p">(</span><span class="nx">key</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC346'>			<span class="k">delete</span> <span class="k">this</span><span class="p">.</span><span class="nx">items</span><span class="p">[</span><span class="nx">key</span><span class="p">];</span></div><div class='line' id='LC347'>		<span class="p">};</span></div><div class='line' id='LC348'>	<span class="p">}</span></div><div class='line' id='LC349'><br/></div><div class='line' id='LC350'><br/></div><div class='line' id='LC351'>	<span class="c1">// Init the buttons</span></div><div class='line' id='LC352'>	<span class="k">if</span> <span class="p">(</span><span class="k">typeof</span> <span class="nb">document</span> <span class="o">!==</span> <span class="s1">&#39;undefined&#39;</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC353'>		<span class="kd">var</span> <span class="nx">ButtonFactory</span> <span class="o">=</span> <span class="nx">PAYPAL</span><span class="p">.</span><span class="nx">apps</span><span class="p">.</span><span class="nx">ButtonFactory</span><span class="p">,</span></div><div class='line' id='LC354'>			<span class="nx">nodes</span> <span class="o">=</span> <span class="nb">document</span><span class="p">.</span><span class="nx">getElementsByTagName</span><span class="p">(</span><span class="s1">&#39;script&#39;</span><span class="p">),</span></div><div class='line' id='LC355'>			<span class="nx">node</span><span class="p">,</span> <span class="nx">data</span><span class="p">,</span> <span class="nx">type</span><span class="p">,</span> <span class="nx">business</span><span class="p">,</span> <span class="nx">i</span><span class="p">,</span> <span class="nx">len</span><span class="p">;</span></div><div class='line' id='LC356'><br/></div><div class='line' id='LC357'>		<span class="k">for</span> <span class="p">(</span><span class="nx">i</span> <span class="o">=</span> <span class="mi">0</span><span class="p">,</span> <span class="nx">len</span> <span class="o">=</span> <span class="nx">nodes</span><span class="p">.</span><span class="nx">length</span><span class="p">;</span> <span class="nx">i</span> <span class="o">&lt;</span> <span class="nx">len</span><span class="p">;</span> <span class="nx">i</span><span class="o">++</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC358'>			<span class="nx">node</span> <span class="o">=</span> <span class="nx">nodes</span><span class="p">[</span><span class="nx">i</span><span class="p">];</span></div><div class='line' id='LC359'><br/></div><div class='line' id='LC360'>			<span class="k">if</span> <span class="p">(</span><span class="o">!</span><span class="nx">node</span> <span class="o">||</span> <span class="o">!</span><span class="nx">node</span><span class="p">.</span><span class="nx">src</span><span class="p">)</span> <span class="p">{</span> <span class="k">continue</span><span class="p">;</span> <span class="p">}</span></div><div class='line' id='LC361'><br/></div><div class='line' id='LC362'>			<span class="nx">data</span> <span class="o">=</span> <span class="nx">node</span> <span class="o">&amp;&amp;</span> <span class="nx">getDataSet</span><span class="p">(</span><span class="nx">node</span><span class="p">);</span></div><div class='line' id='LC363'>			<span class="nx">type</span> <span class="o">=</span> <span class="nx">data</span> <span class="o">&amp;&amp;</span> <span class="nx">data</span><span class="p">.</span><span class="nx">button</span> <span class="o">&amp;&amp;</span> <span class="nx">data</span><span class="p">.</span><span class="nx">button</span><span class="p">.</span><span class="nx">value</span><span class="p">;</span></div><div class='line' id='LC364'>			<span class="nx">business</span> <span class="o">=</span> <span class="nx">node</span><span class="p">.</span><span class="nx">src</span><span class="p">.</span><span class="nx">split</span><span class="p">(</span><span class="s1">&#39;?merchant=&#39;</span><span class="p">)[</span><span class="mi">1</span><span class="p">];</span></div><div class='line' id='LC365'><br/></div><div class='line' id='LC366'>			<span class="k">if</span> <span class="p">(</span><span class="nx">business</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC367'>				<span class="nx">ButtonFactory</span><span class="p">.</span><span class="nx">create</span><span class="p">(</span><span class="nx">business</span><span class="p">,</span> <span class="nx">data</span><span class="p">,</span> <span class="nx">type</span><span class="p">,</span> <span class="nx">node</span><span class="p">.</span><span class="nx">parentNode</span><span class="p">);</span></div><div class='line' id='LC368'><br/></div><div class='line' id='LC369'>				<span class="c1">// Clean up</span></div><div class='line' id='LC370'>				<span class="nx">node</span><span class="p">.</span><span class="nx">parentNode</span><span class="p">.</span><span class="nx">removeChild</span><span class="p">(</span><span class="nx">node</span><span class="p">);</span></div><div class='line' id='LC371'>			<span class="p">}</span></div><div class='line' id='LC372'>		<span class="p">}</span></div><div class='line' id='LC373'>	<span class="p">}</span></div><div class='line' id='LC374'><br/></div><div class='line' id='LC375'><br/></div><div class='line' id='LC376'><span class="p">}());</span></div><div class='line' id='LC377'><br/></div><div class='line' id='LC378'><br/></div><div class='line' id='LC379'><span class="c1">// Export for CommonJS environments</span></div><div class='line' id='LC380'><span class="k">if</span> <span class="p">(</span><span class="k">typeof</span> <span class="nx">module</span> <span class="o">===</span> <span class="s1">&#39;object&#39;</span> <span class="o">&amp;&amp;</span> <span class="k">typeof</span> <span class="nx">module</span><span class="p">.</span><span class="nx">exports</span> <span class="o">===</span> <span class="s1">&#39;object&#39;</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC381'>	<span class="nx">module</span><span class="p">.</span><span class="nx">exports</span> <span class="o">=</span> <span class="nx">PAYPAL</span><span class="p">;</span></div><div class='line' id='LC382'><span class="p">}</span></div></pre></div>
          </td>
        </tr>
      </table>
  </div>

          </div>
        </div>

        <a href="#jump-to-line" rel="facebox" data-hotkey="l" class="js-jump-to-line" style="display:none">Jump to Line</a>
        <div id="jump-to-line" style="display:none">
          <h2>Jump to Line</h2>
          <form accept-charset="UTF-8" class="js-jump-to-line-form">
            <input class="textfield js-jump-to-line-field" type="text">
            <div class="full-button">
              <button type="submit" class="button">Go</button>
            </div>
          </form>
        </div>

      </div>
    </div>
</div>

<div id="js-frame-loading-template" class="frame frame-loading large-loading-area" style="display:none;">
  <img class="js-frame-loading-spinner" src="https://a248.e.akamai.net/assets.github.com/images/spinners/octocat-spinner-128.gif?1347543528" height="64" width="64">
</div>


        </div>
      </div>
      <div class="modal-backdrop"></div>
    </div>

      <div id="footer-push"></div><!-- hack for sticky footer -->
    </div><!-- end of wrapper - hack for sticky footer -->

      <!-- footer -->
      <div id="footer">
  <div class="container clearfix">

      <dl class="footer_nav">
        <dt>GitHub</dt>
        <dd><a href="/about">About us</a></dd>
        <dd><a href="/blog">Blog</a></dd>
        <dd><a href="/contact">Contact &amp; support</a></dd>
        <dd><a href="http://enterprise.github.com/">GitHub Enterprise</a></dd>
        <dd><a href="http://status.github.com/">Site status</a></dd>
      </dl>

      <dl class="footer_nav">
        <dt>Applications</dt>
        <dd><a href="http://mac.github.com/">GitHub for Mac</a></dd>
        <dd><a href="http://windows.github.com/">GitHub for Windows</a></dd>
        <dd><a href="http://eclipse.github.com/">GitHub for Eclipse</a></dd>
        <dd><a href="http://mobile.github.com/">GitHub mobile apps</a></dd>
      </dl>

      <dl class="footer_nav">
        <dt>Services</dt>
        <dd><a href="http://get.gaug.es/">Gauges: Web analytics</a></dd>
        <dd><a href="http://speakerdeck.com">Speaker Deck: Presentations</a></dd>
        <dd><a href="https://gist.github.com">Gist: Code snippets</a></dd>
        <dd><a href="http://jobs.github.com/">Job board</a></dd>
      </dl>

      <dl class="footer_nav">
        <dt>Documentation</dt>
        <dd><a href="http://help.github.com/">GitHub Help</a></dd>
        <dd><a href="http://developer.github.com/">Developer API</a></dd>
        <dd><a href="http://github.github.com/github-flavored-markdown/">GitHub Flavored Markdown</a></dd>
        <dd><a href="http://pages.github.com/">GitHub Pages</a></dd>
      </dl>

      <dl class="footer_nav">
        <dt>More</dt>
        <dd><a href="http://training.github.com/">Training</a></dd>
        <dd><a href="/edu">Students &amp; teachers</a></dd>
        <dd><a href="http://shop.github.com">The Shop</a></dd>
        <dd><a href="/plans">Plans &amp; pricing</a></dd>
        <dd><a href="http://octodex.github.com/">The Octodex</a></dd>
      </dl>

      <hr class="footer-divider">


    <p class="right">&copy; 2013 <span title="0.07980s from fe1.rs.github.com">GitHub</span>, Inc. All rights reserved.</p>
    <a class="left" href="/">
      <span class="mega-octicon octicon-mark-github"></span>
    </a>
    <ul id="legal">
        <li><a href="/site/terms">Terms of Service</a></li>
        <li><a href="/site/privacy">Privacy</a></li>
        <li><a href="/security">Security</a></li>
    </ul>

  </div><!-- /.container -->

</div><!-- /.#footer -->


    <div class="fullscreen-overlay js-fullscreen-overlay" id="fullscreen_overlay">
  <div class="fullscreen-container js-fullscreen-container">
    <div class="textarea-wrap">
      <textarea name="fullscreen-contents" id="fullscreen-contents" class="js-fullscreen-contents" placeholder="" data-suggester="fullscreen_suggester"></textarea>
          <div class="suggester-container">
              <div class="suggester fullscreen-suggester js-navigation-container" id="fullscreen_suggester"
                 data-url="/paypal/JavaScriptButtons/suggestions/commit">
              </div>
          </div>
    </div>
  </div>
  <div class="fullscreen-sidebar">
    <a href="#" class="exit-fullscreen js-exit-fullscreen tooltipped leftwards" title="Exit Zen Mode">
      <span class="mega-octicon octicon-screen-normal"></span>
    </a>
    <a href="#" class="theme-switcher js-theme-switcher tooltipped leftwards"
      title="Switch themes">
      <span class="octicon octicon-color-mode"></span>
    </a>
  </div>
</div>



    <div id="ajax-error-message" class="flash flash-error">
      <span class="octicon octicon-alert"></span>
      Something went wrong with that request. Please try again.
      <a href="#" class="octicon octicon-remove-close ajax-error-dismiss"></a>
    </div>

    
    <span id='server_response_time' data-time='0.08027' data-host='fe1'></span>
    
  </body>
</html>

